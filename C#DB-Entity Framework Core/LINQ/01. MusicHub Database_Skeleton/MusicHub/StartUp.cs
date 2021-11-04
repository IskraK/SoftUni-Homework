namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //string result = ExportAlbumsInfo(context, 9);

            string result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToList()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        Writer = s.Writer.Name
                    })
                    .ToList()
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToList(),
                    AlbumPrice = a.Price
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                //sb.AppendLine($"-AlbumName: {album.AlbumName}");
                //sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}");
                //sb.AppendLine($"-ProducerName: {album.ProducerName}");
                //sb.AppendLine("-Songs:");

                sb.Append($"-AlbumName: {album.AlbumName}\r\n");
                sb.Append($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}\r\n");
                sb.Append($"-ProducerName: {album.ProducerName}\r\n");
                sb.Append("-Songs:\r\n");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    //sb.AppendLine($"---#{counter}");
                    //sb.AppendLine($"---SongName: {song.SongName}");
                    //sb.AppendLine($"---Price: {song.Price:f2}");
                    //sb.AppendLine($"---Writer: {song.Writer}");    // 0/100 in Judge but it works correctly

                    sb.Append($"---#{counter}\r\n");
                    sb.Append($"---SongName: {song.SongName}\r\n");
                    sb.Append($"---Price: {song.Price:f2}\r\n");
                    sb.Append($"---Writer: {song.Writer}\r\n");    // 100/100 in Judge

                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .Select(s => new
                {
                    s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration);

            int counter = 1;

            foreach (var song in songs)
            {
                //sb.AppendLine($"-Song #{counter}");
                //sb.AppendLine($"---SongName: {song.Name}");
                //sb.AppendLine($"---Writer: {song.Writer}");
                //sb.AppendLine($"---Performer: {song.Performer}");
                //sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                //sb.AppendLine($"---Duration: {song.Duration:c}");   // 0/100 in Judge but it works correctly


                //sb.AppendLine($"-Song #{counter}")
                //.AppendLine($"---SongName: {song.Name}")
                //.AppendLine($"---Writer: {song.Writer}")
                //.AppendLine($"---Performer: {song.Performer}")
                //.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                //.AppendLine($"---Duration: {song.Duration:c}");    // 0/100 in Judge but it works correctly

                sb.Append($"-Song #{counter}\r\n");
                sb.Append($"---SongName: {song.Name}\r\n");
                sb.Append($"---Writer: {song.Writer}\r\n");
                sb.Append($"---Performer: {song.Performer}\r\n");
                sb.Append($"---AlbumProducer: {song.AlbumProducer}\r\n");
                sb.Append($"---Duration: {song.Duration:c}\r\n");     // 100/100 in Judge

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
