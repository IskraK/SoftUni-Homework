using Git.Data;
using Git.Data.Models;
using Git.Models.Commits;
using Git.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IValidationService validationService;
        private readonly ApplicationDbContext data;

        public CommitsController(IValidationService validationService, ApplicationDbContext data)
        {
            this.validationService = validationService;
            this.data = data;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data.Repositories
                .Where(r => r.Id == id)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return BadRequest();
            }

            return View(repository);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CommitCreateViewModel model)
        {
            if (!this.data.Repositories.Any(r => r.Id == model.Id))
            {
                return NotFound();
            }

            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            var commit = new Commit
            {
                RepositoryId = model.Id,
                Description = model.Description,
                CreatorId = this.User.Id
            };

            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .Select(c => new CommitListingViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("F")
                })
                .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
