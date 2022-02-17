using Git.Data;
using Git.Data.Models;
using Git.Models.Repositories;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidationService validationService;
        private readonly ApplicationDbContext data;

        public RepositoriesController(IValidationService validationService, ApplicationDbContext data)
        {
            this.validationService = validationService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepositoryCreateViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == "Public",
                OwnerId = this.User.Id
            };

            data.Repositories.Add(repository);
            data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var repositoryQuery= this.data.Repositories.AsQueryable();

            if (!this.User.IsAuthenticated)
            {
                repositoryQuery = repositoryQuery
                    .Where(r => r.IsPublic);
            }
            else
            {
                repositoryQuery = repositoryQuery
                    .Where(r => r.IsPublic || r.OwnerId == this.User.Id);
            }

            var repositories = repositoryQuery
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("F"),
                    CommitsCount = r.Commits.Count()
                })
                .ToList();

            return View(repositories);
        }
    }
}
