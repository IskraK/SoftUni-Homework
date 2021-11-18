using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Problem 01. Import Users
            //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);
            //Console.WriteLine(result);

            //Problem 02. Import Products
            //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
            //string result = ImportProducts(context, inputXml);
            //Console.WriteLine(result);

            //Problem 03. Import Categories
            //string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string result = ImportCategories(context, inputXml);
            //Console.WriteLine(result);

            //Problem 04. Import Categories and Products
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, inputXml);
            //Console.WriteLine(result);

            //Problem 05. Products In Range
            //string result = GetProductsInRange(context);
            //Console.WriteLine(result);

            //Problem 06. Sold Products
            //string result = GetSoldProducts(context);
            //Console.WriteLine(result);

            //Problem 07. Categories By Products Count
            //string result = GetCategoriesByProductsCount(context);
            //Console.WriteLine(result);

            //Problem 08. Users and Products
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }


        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportUsersDto[] dtos = (ImportUsersDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in dtos)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Products");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportProductDto[] dtos = (ImportProductDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Product> products = new HashSet<Product>();

            foreach (var productDto in dtos)
            {
                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = decimal.Parse(productDto.Price),
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Categories");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryDto[] dtos = (ImportCategoryDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Category> categories = new HashSet<Category>();

            foreach (var categoryDto in dtos)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                Category c = new Category()
                {
                    Name = categoryDto.Name
                };

                categories.Add(c);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("CategoryProducts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportCategoryProductDto[] dtos = (ImportCategoryProductDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDto in dtos)
            {
                if (context.Categories.Any(c => c.Id == categoryProductDto.CategoryId)
                    && context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }


        //Problem 05. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer=new XmlSerializer(typeof(ExportProductsInRangeDto[]),new XmlRootAttribute("Products"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            ExportProductsInRangeDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 06. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Where(b => b.Buyer != null)
                    .Select(p => new ExportSoldProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, users, namespaces);

            return sb.ToString().TrimEnd();
        }


        //Problem 07. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductDto[]), new XmlRootAttribute("Categories"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var categories = context.Categories
                .Select(c => new ExportCategoryByProductDto()
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Problem 08. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var users = new ExportUserDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(b => b.Buyer != null)),
                Users = context.Users.ToArray()
                .Where(u => u.ProductsSold.Any(b => b.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new UserSoldProductDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.ToArray()
                        .Where(p => p.Buyer != null)
                       .Select(p => new ExportSoldProductDto()
                       {
                           Name = p.Name,
                           Price = p.Price
                       })
                       .OrderByDescending(p => p.Price)
                       .ToArray()
                    }
                }).ToArray()
            };

            xmlSerializer.Serialize(stringWriter, users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}