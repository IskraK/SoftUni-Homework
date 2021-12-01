namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.ToList()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    })
                    .ToList()
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer),
                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("f2")
                })
                .OrderByDescending(a => decimal.Parse(a.AlbumPrice))
                .ToArray();

            string albumsJson = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return albumsJson;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            using StringWriter stringWriter = new StringWriter(sb);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SongExportDto[]), new XmlRootAttribute("Songs"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var encoding = Encoding.UTF8;

            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new SongExportDto()
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    PerformerFullname = s.SongPerformers.FirstOrDefault().Performer.FirstName + " " 
                                      + s.SongPerformers.FirstOrDefault().Performer.LastName,
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullname)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

//"AlbumName": "Devil's advocate",
//    "ReleaseDate": "07/21/2018",
//    "ProducerName": "Evgeni Dimitrov",
//    "Songs": [
//      {
//        "SongName": "Numb",
//        "Price": "13.99",
//        "Writer": "Kara-lynn Sharpous"
//      },
//      {
//    "SongName": "Ibuprofen",
//        "Price": "26.50",
//        "Writer": "Stanford Daykin"
//      }
//    ],
//    "AlbumPrice": "40.49"
