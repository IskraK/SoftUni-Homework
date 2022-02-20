using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Data.Models;
using SMS.Models.Products;
using SMS.Services;
using System.Globalization;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidationService validationService;

        public ProductsController(SMSDbContext data, IValidationService validationService)
        {
            this.data = data;
            this.validationService = validationService;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return Error(errors);
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05M || price > 1000M)
            {
                return Error("Price must be between 0.05 and 1000");
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            data.Products.Add(product);
            data.SaveChanges();

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
