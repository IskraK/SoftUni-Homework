using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidationService validationService;

        public CarsController(ApplicationDbContext data, IValidationService validationService)
        {
            this.data = data;
            this.validationService = validationService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            bool isMechanic = this.data.Users.Any(u => u.Id == this.User.Id && u.IsMechanic == true);

            if (isMechanic)
            {
                return Error("Mechanics cannot add cars.");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CarAddViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = this.User.Id
            };

            data.Cars.Add(car);
            data.SaveChanges();

            return Redirect("Cars/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var carsQuery = this.data.Cars.AsQueryable();

            bool userIsMechanic = this.data.Users.Any(u => u.Id == this.User.Id && u.IsMechanic == true);

            if (userIsMechanic)
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => i.IsFixed == false));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == this.User.Id);
            }

            var cars = carsQuery.Select(c => new CarListViewModel()
            {
                Id = c.Id,
                Model = c.Model,
                Year = c.Year,
                PlateNumber =c.PlateNumber,
                Image = c.PictureUrl,
                FixedIssues = c.Issues.Count(i => i.IsFixed),
                RemainingIssues = c.Issues.Count(i => i.IsFixed == false)
            })
                .ToList();

            return View(cars);
        }
    }
}

