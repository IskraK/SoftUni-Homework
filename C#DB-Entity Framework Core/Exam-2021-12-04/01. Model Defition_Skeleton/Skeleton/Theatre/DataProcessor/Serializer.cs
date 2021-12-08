namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(tk => tk.RowNumber >= 1 && tk.RowNumber <= 5).Sum(tk => tk.Price),
                    Tickets = t.Tickets
                    .Where(tk => tk.RowNumber >= 1 && tk.RowNumber <= 5)
                    .Select(tk => new
                    {
                        //Price = decimal.Round(tk.Price, 2),
                        Price = decimal.Parse(tk.Price.ToString("f2")),
                        RowNumber = tk.RowNumber
                    }).ToList()
                    .OrderByDescending(tk => tk.Price)
                }).ToList()
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            string theatresJson = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return theatresJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayExportDto[]), new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var plays = context.Plays.ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new PlayExportDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter == true)
                    .Select(c => new ActorDto
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{c.Play.Title}'"
                    })
                    .OrderByDescending(c => c.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, plays, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

//Use the method provided in the project skeleton, which receives a rating. Export all plays with a rating equal or smaller to the given. For each play, export Title, Duration (in the format: "c"), Rating, Genre, and Actors which play the main character only. 
//Keep in mind:
//•	If the rating is 0, you should print "Premier". 
//•	For each actor display:
//o FullName 
//o	MainCharacter in the format: "Plays main character in '{playTitle}'."
//Order the result by play title (ascending), then by genre (descending). Order actors by their full name descending.
