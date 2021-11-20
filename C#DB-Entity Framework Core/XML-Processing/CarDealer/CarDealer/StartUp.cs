using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Query 9. Import Suppliers
            //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(context, inputXml);

            //Query 10. Import Parts
            //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string result = ImportParts(context, inputXml);

            //Query 11. Import Cars
            //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string result = ImportCars(context, inputXml);

            //Query 12. Import Customers
            //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string result = ImportCustomers(context, inputXml);

            //Query 13. Import Sales
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            //string result = ImportSales(context, inputXml);

            //Query 14. Cars With Distance
            //string result = GetCarsWithDistance(context);

            //Query 15. Cars from make BMW
            //string result = GetCarsFromMakeBmw(context);

            //Query 16. Local Suppliers
            //string result = GetLocalSuppliers(context);

            //Query 17. Cars with Their List of Parts
            //string result = GetCarsWithTheirListOfParts(context);

            //Query 18. Total Sales by Customer
            //string result = GetTotalSalesByCustomer(context);

            //Query 19. Sales with Applied Discount
            string result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }


        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),new XmlRootAttribute("Suppliers"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var supplierDto in dtos)
            {
                Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImporter)
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }


        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartDto[] dtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Part> parts = new HashSet<Part>();

            foreach (var partDto in dtos)
            {
                Supplier supplier = context.Suppliers.Find(partDto.SupplierId);

                if (supplier is null)
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = partDto.Name,
                    Price = decimal.Parse(partDto.Price),
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };

                parts.Add(part);
            }

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] dtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Car> cars = new HashSet<Car>();

            foreach (var carDto in dtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                ICollection<PartCar> carParts = new HashSet<PartCar>();

                foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context.Parts.Find(partId);

                    if (part is null)
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    };

                    carParts.Add(partCar);
                }

                car.PartCars = carParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomerDto[] dtos = (ImportCustomerDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var customerDto in dtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = DateTime.Parse(customerDto.BirthDate),
                    IsYoungDriver = bool.Parse(customerDto.IsYoungDriver)
                };

                customers.Add(customer);
            }

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }


        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            using StringReader stringReader = new StringReader(inputXml);

            ImportSaleDto[] dtos = (ImportSaleDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var saleDto in dtos)
            {
                if (context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    Sale sale = new Sale()
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = decimal.Parse(saleDto.Discount)
                    };

                    sales.Add(sale);
                }
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Query 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarBmwDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarBmwDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, bmwCars, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 17. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarWithPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(p => new ExportPartCarDto()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, cars, namespaces);

            return sb.ToString().TrimEnd();
        }


        //Query 18. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesCustomerDto[]), new XmlRootAttribute("customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new ExportTotalSalesCustomerDto()
                {
                    Name = c.Name,
                    BoughtCarsCount = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(p => p.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 19. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSalesWithDiscountDto[]),new XmlRootAttribute("sales"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sales = context.Sales
                .Select(s => new ExportSalesWithDiscountDto()
                {
                    Car = new ExportCarSalesDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance.ToString()
                    },
                    Discount = s.Discount.ToString(),
                    CustomerName = s.Customer.Name,
                    Price=s.Car.PartCars.Sum(p => p.Part.Price).ToString(),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) - s.Car.PartCars.Sum(p => p.Part.Price)*s.Discount / 100).ToString()
                })
                .ToArray();

            xmlSerializer.Serialize(stringWriter, sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}