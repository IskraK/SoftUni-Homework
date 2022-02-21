using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IValidationService validationService;
        private readonly FootballManagerDbContext data;

        public PlayersController(IValidationService validationService, FootballManagerDbContext data)
        {
            this.validationService = validationService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(PlayerAddViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            Player player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            data.Players.Add(player);
            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = data.Players
                .Where(p => p.UserPlayers.Any(u => u.UserId == this.User.Id))
                .Select(p => new PlayerListViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Position = p.Position,
                    ImageUrl = p.ImageUrl,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userPlayers = data.UserPlayers
                .Where(u => u.UserId == this.User.Id)
                .Select(p => p.Player)
                .ToList();

            var players = userPlayers
                .Select(p => new PlayerListViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Position = p.Position,
                    ImageUrl = p.ImageUrl,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description
                })
                .ToList();

            return View(players);

            //var collection = this.data
            //    .UserPlayers
            //    .Where(u => u.UserId == this.User.Id)
            //    .Select(p => new PlayerListViewModel
            //    {
            //        Id = p.Player.Id,
            //        Description = p.Player.Description,
            //        Endurance = p.Player.Endurance,
            //        FullName = p.Player.FullName,
            //        Position = p.Player.Position,
            //        ImageUrl = p.Player.ImageUrl,
            //        Speed = p.Player.Speed
            //    })
            //    .ToList();


            //return View(collection);
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var user = data.Users
                .FirstOrDefault(u => u.Id == this.User.Id);
            var player = data.Players
                .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                return NotFound();
            }

            if (this.data.UserPlayers.Any(p => p.PlayerId == playerId && p.UserId == this.User.Id))
            {
                return Error($"The player {player.FullName} is already added to the collection.");
            }

            UserPlayer userPlayer = new UserPlayer()
            {
                PlayerId = playerId,
                UserId = this.User.Id,
                User = user,
                Player = player
            };

            user.UserPlayers.Add(userPlayer);

            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var user = data.Users.FirstOrDefault(u => u.Id == this.User.Id);
            var player = data.Players.Find(playerId);
            var userPlayer = data.UserPlayers.FirstOrDefault(u => u.UserId == this.User.Id && u.PlayerId == playerId);

            if (player == null || user == null || userPlayer == null)
            {
                return BadRequest();
            }

            user.UserPlayers.Remove(userPlayer);
            data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }
}
