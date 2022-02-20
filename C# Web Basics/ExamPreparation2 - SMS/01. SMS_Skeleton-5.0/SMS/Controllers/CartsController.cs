using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Models;
using SMS.Models.Products;
using System.Linq;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            //var user = this.data.Users
            //    .Where(u => u.Id == this.User.Id)
            //    .Include(u => u.Cart)
            //    .ThenInclude(c => c.Products)
            //    .FirstOrDefault();

            //var product = this.data.Products
            //    .FirstOrDefault(p => p.Id == productId);

            //user.Cart.Products.Add(product);

            //data.SaveChanges();

            //var products = user.Cart.Products
            //    .Select(p => new CartViewModel
            //    {
            //        Name = p.Name,
            //        Price = p.Price.ToString("F2"),
            //    });

            var product = this.data.Products
                .FirstOrDefault(p => p.Id == productId);

            var cart = this.data.Carts
                .FirstOrDefault(c => c.User.Id == this.User.Id);    

            cart.Products.Add(product);

            this.data.SaveChanges();

            var products = this.data.Carts
                .Where(c => c.User.Id == this.User.Id)
                .SelectMany(x => x.Products)
                .Select(x => new AddViewModel
                {
                    Id = productId,
                    Name = product.Name,
                    Price = product.Price.ToString("F2"),
                })
                .ToList();

            return View("/Carts/Details", products);
        }

        [Authorize]
        public HttpResponse Details()
        {
            var cart = this.data.Carts
                .Where(c => c.User.Id == this.User.Id)
                .FirstOrDefault();

            var products = this.data.Products
                .Where(p => p.CartId == cart.Id)
                .Select(p => new CartViewModel
                {
                    Name = p.Name,
                    Price = p.Price.ToString("F2"),
                })
                .ToArray();

            return View(products);
        }

        [Authorize]
        public HttpResponse Buy()
        {
            var cart = this.data.Carts
                .Where(c => c.User.Id == this.User.Id)
                .FirstOrDefault();

            var cartProducts = this.data.Products
                .Where(p => p.CartId == cart.Id)
                .ToArray();

            foreach (var product in cartProducts)
            {
                product.CartId = null;
            }

            this.data.Carts.Update(cart);
            this.data.SaveChanges();

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
