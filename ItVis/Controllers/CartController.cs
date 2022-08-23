using ItVis.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ItVis.DbRepository;
using Microsoft.EntityFrameworkCore;

namespace ItVis.Controllers
{
    public class CartController : Controller
    {
        private ApplicationContext _db;
        public CartController(ApplicationContext context) => _db = context;

        public async Task<IActionResult> Cart()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                var productsCart = _db.Carts.Where(c => c.UserId == HttpContext.Session.GetInt32("UserId"))
                    .Include(p => p.UserCart).ToList();

                CartViewModel cartModel = new CartViewModel
                {
                    ProductTypes = _db.ProductTypes,
                };
                return View(cartModel);
            }

            return View();
        }
        public async Task<IActionResult> InCart()
        {
            return View();
        }
    }
}
