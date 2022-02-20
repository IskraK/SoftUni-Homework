namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Data;
    using SMS.Models;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }
        public HttpResponse Index()
        {
            return View();
        }

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var user = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);
            var products = this.data.Products.ToList();

            var model = new LoggedInIndexViewModel()
            {
                Username = user.Username,
                Email = user.Email,
                Products = products,
            };

            return View(model);
        }
    }
}