using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Models.Users;
using SMS.Services;
using System.Linq;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidationService validationService;
        private readonly SMSDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidationService validationService, SMSDbContext data, IPasswordHasher passwordHasher)
        {
            this.validationService = validationService;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            Cart cart = new Cart();

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email,
                Cart = cart,
                CartId = cart.Id
            }; 

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Login(LoginViewModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Login incorrect");
            }

            this.SignIn(userId);

            return Redirect("/Home/IndexLoggedIn");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
