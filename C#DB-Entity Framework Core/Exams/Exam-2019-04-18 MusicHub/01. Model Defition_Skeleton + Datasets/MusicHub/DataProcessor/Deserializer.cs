namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<WriterImportDto> writerDtos = JsonConvert.DeserializeObject<List<WriterImportDto>>(jsonString);
            List<Writer> writers = new List<Writer>();

            foreach (var writerDto in writerDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Writer writer = new Writer()
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine($"Imported {writer.Name}");
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<ProducerImportDto> producerDtos = JsonConvert.DeserializeObject<List<ProducerImportDto>>(jsonString);
            List<Producer> producers = new List<Producer>();

            foreach (var producerDto in producerDtos)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer()
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                bool isAllAlbumsValid = true;

                foreach (var albumDto in producerDto.Albums)
                {
                    if (!IsValid(albumDto))
                    {
                        isAllAlbumsValid = false;
                        break;
                    }

                    bool isValidReleaseDate = DateTime.TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                    if (!isValidReleaseDate)
                    {
                        isAllAlbumsValid = false;
                        break;
                    }

                    Album album = new Album()
                    {
                        Name = albumDto.Name,
                        ReleaseDate = releaseDate
                    };

                    producer.Albums.Add(album);
                }

                if (!isAllAlbumsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                producers.Add(producer);
                string message = producer.PhoneNumber != null ? $"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count} albums" : $"Imported {producer.Name} with no phone number produces {producer.Albums.Count} albums";
                sb.AppendLine(message);
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SongImportDto[]), new XmlRootAttribute("Songs"));

            using StringReader stringReader = new StringReader(xmlString);

            SongImportDto[] songDtos = (SongImportDto[])xmlSerializer.Deserialize(stringReader);
            List<Song> songs = new List<Song>();

            foreach (var songDto in songDtos)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidCreatedOn = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdOn);

                if (!isValidCreatedOn)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidDuration= TimeSpan.TryParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                if (!isValidDuration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidGenre = Enum.TryParse<Genre>(songDto.Genre.ToString(), out Genre genre);
                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Album album = context.Albums.FirstOrDefault(a => a.Id == songDto.AlbumId);
                if (album is null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Writer writer = context.Writers.FirstOrDefault(w => w.Id == songDto.WriterId);
                if (writer is null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Song song = new Song()
                {
                    Name = songDto.Name,
                    CreatedOn = createdOn,
                    Duration = duration,
                    Genre = genre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price=songDto.Price
                };

                songs.Add(song);
                sb.AppendLine($"Imported {song.Name} ({song.Genre} genre) with duration {song.Duration.ToString("c")}");
            }

            context.Songs.AddRange(songs);
            context.SaveChangesAsync();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PerformerSongsDto[]), new XmlRootAttribute("Performers"));

            using StringReader stringReader = new StringReader(xmlString);

            PerformerSongsDto[] performerDtos = (PerformerSongsDto[])xmlSerializer.Deserialize(stringReader);
            List<Performer> performers = new List<Performer>();

            foreach (var performerDto in performerDtos)
            {
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Performer performer = new Performer()
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                };

                bool isAllSongsValid = true;

                foreach (var songDto in performerDto.PerformerSongs)
                {
                    Song song = context.Songs.Find(songDto.Id);

                    if (song is null)
                    {
                        isAllSongsValid = false;
                        break;
                    }

                    performer.PerformerSongs.Add(new SongPerformer { Song=song, Performer=performer});
                }

                if (!isAllSongsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                performers.Add(performer);
                sb.AppendLine($"Imported {performer.FirstName} ({performer.PerformerSongs.Count} songs)");
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}