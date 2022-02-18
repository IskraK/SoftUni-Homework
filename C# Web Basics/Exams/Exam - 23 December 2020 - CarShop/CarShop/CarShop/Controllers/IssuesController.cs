using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidationService validationService;

        public IssuesController(ApplicationDbContext data, IValidationService validationService)
        {
            this.data = data;
            this.validationService = validationService;
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            var issue = new AddIssueViewModel
            {
                CarId = carId
            };

            return View(issue);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            bool userIsMechanic = this.data.Users.Any(u => u.Id == this.User.Id && u.IsMechanic == true);

            if (!userIsMechanic)
            {
                bool userOwnsCar = this.data.Cars.Any(c => c.OwnerId == this.User.Id && c.Id == model.CarId);

                if (!userOwnsCar)
                {
                    return Unauthorized();
                }
            }

            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            Issue issue = new Issue()
            {
                CarId = model.CarId,
                Description = model.Description,
            };

            this.data.Issues.Add(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            bool userIsMechanic = this.data.Users.Any(u => u.Id == this.User.Id && u.IsMechanic == true);

            if (!userIsMechanic)
            {
                bool userOwnsCar = this.data.Cars.Any(c => c.OwnerId == this.User.Id && c.Id == carId);

                if (!userOwnsCar)
                {
                    return Unauthorized();
                }
            }

            var carIssues = this.data.Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    UserIsMechanic = userIsMechanic,
                    Issues = c.Issues
                    .Select( i => new IssueListViewModel()
                    {
                        Id=i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed,
                        FixedInformation = i.IsFixed ? "Yes" : "Not Yet"
                    }).ToList()
                })
                .FirstOrDefault();

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            bool userIsMechanic = this.data.Users.Any(u => u.Id == this.User.Id && u.IsMechanic == true);

            if (!userIsMechanic)
            {
                return Unauthorized();
            }

            //var issue = this.data.Issues
            //    .Where(i => i.Id == issueId && i.CarId == carId)
            //    .FirstOrDefault();

            var issue = this.data.Issues.Find(issueId);

            if (issue == null)
            {
                return NotFound();
            }

            issue.IsFixed = true;
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var issue = this.data.Issues.Find(issueId);

            if (issue == null)
            {
                return NotFound();
            }

            this.data.Issues.Remove(issue);
            this.data.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
