namespace Cinema.DataProcessor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Cinema.DataProcessor.XmlHelper;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            MovieImportDto[] movieDtos = JsonConvert.DeserializeObject<MovieImportDto[]>(jsonString);
            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in movieDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (movies.Any(m => m.Title == movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie movie = new Movie()
                {
                    Title = movieDto.Title,
                    Genre = (Genre)movieDto.Genre,
                    Duration = TimeSpan.Parse(movieDto.Duration),
                    Director = movieDto.Director,
                    Rating = movieDto.Rating
                };

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            HallImportDto[] hallDtos = JsonConvert.DeserializeObject<HallImportDto[]>(jsonString);
            List<Hall> halls = new List<Hall>();

            foreach (var hallDto in hallDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (hallDto.Seats <= 0 )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall()
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat() { Hall = hall });
                }

                string projectionType;
                if ((bool)hall.Is3D && (bool)hall.Is4Dx)
                {
                    projectionType = "4Dx/3D";
                }
                else if ((bool)hall.Is3D)
                {
                    projectionType = "3D";
                }
                else if ((bool)hall.Is4Dx)
                {
                    projectionType = "4Dx";
                }
                else
                {
                    projectionType = "Normal";
                }

                halls.Add(hall);
                sb.AppendLine($"Successfully imported {hall.Name}({projectionType}) with {hall.Seats.Count} seats!");
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectionImportDto[]), new XmlRootAttribute("Projections"));

            using StringReader stringReader = new StringReader(xmlString);

            ProjectionImportDto[] projectionDtos = (ProjectionImportDto[])xmlSerializer.Deserialize(stringReader);
            List<Projection> projections = new List<Projection>();

            foreach (var projectionDto in projectionDtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDate = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Movie movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                if (movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Halls.Any(h => h.Id == projectionDto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Projection projection = new Projection()
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = date
                };

                projections.Add(projection);
                sb.AppendLine($"Successfully imported projection {movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}!");
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerTicketImportDto[]), new XmlRootAttribute("Customers"));

            using StringReader stringReader = new StringReader(xmlString);

            CustomerTicketImportDto[] customerDtos = (CustomerTicketImportDto[])xmlSerializer.Deserialize(stringReader);
            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        continue;
                    }

                    Projection projection = context.Projections.FirstOrDefault(p => p.Id == ticketDto.ProjectionId);
                    if (projection == null)
                    {
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Customer = customer,
                        Price = ticketDto.Price,
                        Projection = projection
                    };

                    customer.Tickets.Add(ticket);
                }

                customers.Add(customer);
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}