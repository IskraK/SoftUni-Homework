namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesByGenres = context.Genres.ToList()
				.Where(g => genreNames.Contains(g.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Select(g => new
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
						Players = g.Purchases.Count
					})
					.Where(g => g.Players > 0)
					.OrderByDescending(g => g.Players)
					.ThenBy(g => g.Id),
					TotalPlayers = x.Games.Sum(g => g.Purchases.Count)
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToList();

			string jsonResult = JsonConvert.SerializeObject(gamesByGenres,Formatting.Indented);

			return jsonResult;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			StringBuilder sb = new StringBuilder();

			using StringWriter stringWriter = new StringWriter(sb);

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserExportDto[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			var users = context.Users.ToList()
				.Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(u => new UserExportDto
				{
					Username = u.Username,
					Purchases = (PurchaseExportDto[])u.Cards.SelectMany(c => c.Purchases)
					.Where(p => p.Type.ToString() == storeType)
					.Select(p => new PurchaseExportDto
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameExportDto
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.OrderBy(p => p.Date).ToArray(),
					TotalSpent = u.Cards
					.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType)
					.Sum(p => p.Game.Price))
				})
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			xmlSerializer.Serialize(stringWriter, users, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}