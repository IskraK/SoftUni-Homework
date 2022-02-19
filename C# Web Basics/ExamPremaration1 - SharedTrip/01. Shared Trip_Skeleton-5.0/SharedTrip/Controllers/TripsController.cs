using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidationService validationService;

        public TripsController(ApplicationDbContext data, IValidationService validationService)
        {
            this.data = data;
            this.validationService = validationService;
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Seats = model.Seats,
                ImagePath = model.ImagePath,
                Description = model.Description,
            };

            DateTime date;

            DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);

            trip.DepartureTime = date;

            data.Trips.Add(trip);
            data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var tripsQuery = data.Trips.AsQueryable();

            var trips = tripsQuery
                .Select(t => new TripListViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm")
                })
                .ToList();

            return View(trips);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.data.Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = t.Description,
                    ImagePath = t.ImagePath
                })
                .FirstOrDefault();

            return View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var user = data.Users
                .FirstOrDefault(u => u.Id == this.User.Id);
            var trip = data.Trips
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                return NotFound();
            }

            if (this.data.UserTrips.Any(t => t.TripId == tripId && t.UserId == this.User.Id))
            {
                return Redirect($"/Trips/Details?tripId={tripId} ");
            }

            trip.Seats -= 1;

            if (trip.Seats < 0)
            {
                return Error("There are no seats for that trip!");
            }

            UserTrip userTrip = new UserTrip()
            {
                TripId = tripId,
                UserId = this.User.Id,
                User = user,
                Trip = trip
            };

            user.UserTrips.Add(userTrip);

            data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
