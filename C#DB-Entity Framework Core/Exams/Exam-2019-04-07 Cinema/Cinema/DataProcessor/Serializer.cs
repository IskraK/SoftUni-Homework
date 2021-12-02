namespace Cinema.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.DataProcessor.XmlHelper;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            //var movies = context.Movies.ToArray()
            //    .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
            //    .Select(m => new
            //    {
            //        MovieName = m.Title,
            //        Rating = m.Rating.ToString("f2"),
            //        TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
            //        Customers = m.Projections.SelectMany(p => p.Tickets.Select(t => new
            //        {
            //            FirstName = t.Customer.FirstName,
            //            LastName = t.Customer.LastName,
            //            Balance = t.Customer.Balance.ToString("f2")
            //        }))
            //        .ToArray()
            //        .OrderByDescending(c => decimal.Parse(c.Balance))
            //        .ThenBy(c => c.FirstName)
            //        .ThenBy(c => c.LastName)
            //    })
            //    .OrderByDescending(m => double.Parse(m.Rating))
            //    .ThenByDescending(m => decimal.Parse(m.TotalIncomes))
            //    .Take(10)
            //    .ToArray();

            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(y => y.Tickets.Count > 0))
                .ToList()
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections
                    .Sum(y => y.Tickets
                        .Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("f2"),
                    Customers = x.Projections
                        .SelectMany(p => p.Tickets
                            .Select(t => new
                            {
                                FirstName = t.Customer.FirstName,
                                LastName = t.Customer.LastName,
                                Balance = t.Customer.Balance.ToString("f2")
                            })
                        .ToList())
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToList()
                })
                .Take(10)
                .ToList();

            string moviesJson = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return moviesJson;
        }


        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerExportDto[]), new XmlRootAttribute("Customers"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var customers = context.Customers
                            .ToList()
                            .Where(c => c.Age >= age)
                            .Select(c => new CustomerExportDto()
                            {
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                SpentMoney = decimal.Parse(c.Tickets.Sum(t => t.Price).ToString("f2")),
                                SpentTime = TimeSpan
                                    .FromMilliseconds(c.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                                    .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)
                            })
                            .OrderByDescending(c => c.SpentMoney)
                            .Take(10)
                            .ToArray();

            xmlSerializer.Serialize(stringWriter, customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

//{
//    "MovieName": "SIS",
//    "Rating": "10.00",
//    "TotalIncomes": "184.04",
//    "Customers": [
//      {
//        "FirstName": "Davita",
//        "LastName": "Lister",
//        "Balance": "279.76"
//      },
//      {
//        "FirstName": "Arluene",
//        "LastName": "Farman",
//        "Balance": "118.33"
//      {
