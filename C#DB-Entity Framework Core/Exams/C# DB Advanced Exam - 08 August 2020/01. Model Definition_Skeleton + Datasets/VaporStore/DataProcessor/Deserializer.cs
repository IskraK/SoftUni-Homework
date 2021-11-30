namespace VaporStore.DataProcessor
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
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			GameImportDto[] gameDtos = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);
			List<Game> games = new List<Game>();
			List<Developer> developers = new List<Developer>();
			List<Genre> genres = new List<Genre>();
			List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isValidReleaseDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                if (!isValidReleaseDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Game game = new Game()
				{
					Name = gameDto.Name,
					Price = gameDto.Price,
					ReleaseDate = releaseDate
				};

				Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer is null)
                {
					developer = new Developer() { Name = gameDto.Developer };
					developers.Add(developer);
                }

				game.Developer = developer;

				Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre is null)
                {
					genre = new Genre() { Name = gameDto.Genre };
					genres.Add(genre);
                }

				game.Genre = genre;

                foreach (var tagDto in gameDto.Tags)
                {
					Tag tag = tags.FirstOrDefault(t => t.Name == tagDto);
                    if (tag is null)
                    {
						tag = new Tag() { Name = tagDto };
						tags.Add(tag);
                    }

					game.GameTags.Add(new GameTag() { Tag = tag });
                }

				games.Add(game);
				sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameDto.Tags.Length} tags");
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			UserImportDto[] userDtos = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);
			List<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				User user = new User()
				{
					Username = userDto.Username,
					FullName = userDto.FullName,
					Age = userDto.Age,
					Email = userDto.Email,
					Cards = userDto.Cards.Select(c => new Card()
					{
						Number = c.Number,
						Cvc = c.Cvc,
						Type = c.Type.Value
					})
					.ToList()
				};

				users.Add(user);
				sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Length} cards");
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseImportDto[]), new XmlRootAttribute("Purchases"));

			using StringReader stringReader = new StringReader(xmlString);

			PurchaseImportDto[] purchaseDtos = (PurchaseImportDto[])xmlSerializer.Deserialize(stringReader);
			List<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				bool isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isValidDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				Purchase purchase = new Purchase()
				{
					ProductKey = purchaseDto.Key,
					Type = purchaseDto.Type.Value,
					Date = date,
					Card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card),
					Game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Game)
				};

				purchases.Add(purchase);
				sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

			context.Purchases.AddRange(purchases);
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