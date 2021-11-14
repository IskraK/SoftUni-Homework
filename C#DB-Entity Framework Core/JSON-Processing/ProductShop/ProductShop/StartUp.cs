using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Problem 01. Import Users
            //string usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, usersJsonAsString));

            //Problem 02. Import Products
            //string productsJson = File.ReadAllText("../../../Datasets/products.json");
            //string result = ImportProducts(context, productsJson);
            //Console.WriteLine(result);

            //Problem 03. Import Categories
            //string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(context, categoriesJson);
            //Console.WriteLine(result);

            //Problem 04. Import Categories and Products
            //string categoryProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, categoryProductsJson);
            //Console.WriteLine(result);

            //Problem 05.Export Products in Range
            //string result = GetProductsInRange(context);
            //Console.WriteLine(result);

            //Problem 06. Export Successfully Sold Products
            //string result = GetSoldProducts(context);
            //Console.WriteLine(result);

            //Problem 07.Export Categories by Products Count
            //string result = GetCategoriesByProductsCount(context);
            //Console.WriteLine(result);

            //Problem 08. Export Users and Products
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }


        //Problem 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";

            //Second decision with AutoMapper
            //IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);
            //InitializeMapper();

            //var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            //context.Users.AddRange(mappedUsers);
            //context.SaveChanges();

            //return $"Successfully imported {mappedUsers.Count()}";
        }

        //Problem 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";

            //Second decision with AutoMapper
            //IEnumerable<ProductInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);
            //InitializeMapper();

            //var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            //context.Products.AddRange(mappedProducts);
            //context.SaveChanges();

            //return $"Successfully imported {mappedProducts.Count()}";
        }


        //Problem 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson)
                .Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";

            //Second decision with AutoMapper
            //IEnumerable<CategoryInputDto> categories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputDto>>(inputJson)
            //    .Where(c => !string.IsNullOrEmpty(c.Name));
            //InitializeMapper();

            //var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            //context.Categories.AddRange(mappedCategories);
            //context.SaveChanges();

            //return $"Successfully imported {mappedCategories.Count()}";
        }


        //Problem 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";

            //Second decision with AutoMapper
            //IEnumerable<CategoryProductDto> categoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);
            //InitializeMapper();

            //var mappedCategoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoryProducts);

            //context.CategoryProducts.AddRange(mappedCategoryProducts);
            //context.SaveChanges();

            //return $"Successfully imported {mappedCategoryProducts.Count()}";
        }


        //Problem 05.Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string productsAsJson = JsonConvert.SerializeObject(products, jsonSettings);

            return productsAsJson;
        }


        //Problem 06. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(b => b.Buyer != null) && u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string usersAsJson = JsonConvert.SerializeObject(users, jsonSettings);

            return usersAsJson;
        }


        //Problem 07.Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //var categories = context.Categories
            //    .OrderByDescending(c => c.CategoryProducts.Count)
            //    .Select(c => new
            //    {
            //        Category = c.Name,
            //        ProductsCount = c.CategoryProducts.Count,
            //        AveragePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
            //        TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
            //    })
            //    .ToList();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{(c.CategoryProducts.Sum(p => p.Product.Price)/c.CategoryProducts.Count):f2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string categoriesAsJson = JsonConvert.SerializeObject(categories,jsonSettings);

            return categoriesAsJson;
        }


        //Problem 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Any(b => b.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(b => b.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(b => b.Buyer != null),
                        Products = u.ProductsSold
                        .Where(b => b.Buyer != null)
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                    }
                })
                .ToList();

            var userWithProducts = new
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling=NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };

            string usersAsJson = JsonConvert.SerializeObject(userWithProducts, jsonSettings);

            return usersAsJson;
        }


        private static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            mapper = new Mapper(mapperConfiguration);
        }
    }
}