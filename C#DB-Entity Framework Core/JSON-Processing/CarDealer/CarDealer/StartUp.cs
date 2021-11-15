using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Problem 09. Import Suppliers
            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, suppliersJson);
            //Console.WriteLine(result);

            //Problem 10. Import Parts
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //string result = ImportParts(context, partsJson);
            //Console.WriteLine(result);


            //Problem 11. Import Cars
            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //string result = ImportCars(context, carsJson);
            //Console.WriteLine(result);

            //Problem 12. Import Customers
            //string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //string result = ImportCustomers(context, customersJson);
            //Console.WriteLine(result);

            //Problem 13. Import Sales
            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(context, salesJson);
            //Console.WriteLine(result);

            //Problem 14. Export Ordered Customers
            //string result = GetOrderedCustomers(context);
            //Console.WriteLine(result);

            //Problem 15.Export Cars from Make Toyota
            //string result = GetCarsFromMakeToyota(context);
            //Console.WriteLine(result);

            //Problem 16. Export Local Suppliers
            //string result = GetLocalSuppliers(context);
            //Console.WriteLine(result);

            //Problem 17. Export Cars with Their List of Parts
            //string result = GetCarsWithTheirListOfParts(context);
            //Console.WriteLine(result);

            //Problem 18. Export Total Sales by Customer
            //string result = GetTotalSalesByCustomer(context);
            //Console.WriteLine(result);

            //Problem 19. Export Sales with Applied Discount
            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }


        //Problem 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Problem 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarInputDto> carsDto = JsonConvert.DeserializeObject<List<CarInputDto>>(inputJson);
            List<Car> cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string customersAsJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersAsJson;
        }

        //Problem 15.Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string carsAsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsAsJson;
        }

        //Problem 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string suppliersAsJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersAsJson;
        }

        //Problem 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new 
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                    .Select(p => new { Name = p.Part.Name, Price = $"{ p.Part.Price:F2}" })
                    .ToList()
                })
                .ToList();

            string carsAsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsAsJson;
        }

        //Problem 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                }).ToList()
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            string customersAsJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersAsJson;
        }

        //Problem 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
                    priceWithDiscount = $"{(s.Car.PartCars.Sum(pc => pc.Part.Price)*(1 -s.Discount/100m)):f2}"
                })
                .Take(10)
                .ToList();

            string salesAsJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesAsJson;
        }
    }
}