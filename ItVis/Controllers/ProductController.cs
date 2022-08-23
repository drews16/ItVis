using ItVis.Models;
using ItVis.DbRepository;
using ItVis.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItVis.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationContext _db;
        public ProductController(ApplicationContext context) => _db = context;

        [HttpGet]
        public IActionResult ProductList(string category, int page = 1)
        {
            var products = _db.Products
                .Include(p => p.ProductType)
                .Include(p => p.Brand);

            int pageSize = 8;

            var count = products.Count(c => c.ProductType.TypeName == category);
            var items = products.Where(c => c.ProductType.TypeName == category)
                .Skip((page - 1) * pageSize).Take(pageSize);

            PagingViewModel paging = new PagingViewModel(count, page, pageSize);

            ProductPageViewModel productPage = new ProductPageViewModel
            {
                CurrentCategory = category,
                PageInfo = paging,
                Products = items,
                ProductTypes = _db.ProductTypes,
                Brands = _db.Brands
            };

            return View(productPage);
        }

        public async Task<IActionResult> SearchProduct(string searchString, int page = 1)
        {
            List<Product> searchProducts = new List<Product>();

            if (!String.IsNullOrEmpty(searchString))
            {
                searchProducts = await _db.Products.Include(p => p.Brand)
                    .Where(p => p.Brand.BrandName.Contains(searchString) || p.Model.Contains(searchString)).ToListAsync();
            }

            if(searchProducts.Count != 0)
            {
                int pageSize = 8;

                var count = searchProducts.Count();
                var items = searchProducts
                    .Skip((page - 1) * pageSize).Take(pageSize);

                PagingViewModel paging = new PagingViewModel(count, page, pageSize);

                SearchViewModel searchModel = new SearchViewModel
                {
                    SearchString = searchString,
                    Products = items,
                    PageInfo = paging,
                    ProductTypes = _db.ProductTypes
                };

                return View(searchModel);
            }
            else
            {
                return RedirectToAction("SearchProductFailed");
            }
        }

        [HttpGet]
        public IActionResult SearchProductFailed()
        {
            MainPageViewModel mainPage = new MainPageViewModel
            { 
                ProductTypes = _db.ProductTypes
            };

            return PartialView("/Views/Product/_SearchProductFailed.cshtml", mainPage);
        }

        [HttpGet]
        public async Task<IActionResult> Property(int id)
        {
            var products = _db.Products.Include(p => p.Brand);
            Product? product = await products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                IEnumerable<ProductProperty> productProperties = _db.ProductsProperties
                    .Where(p => p.ProductId == id);

                ProductPropertyViewModel productProperty = new ProductPropertyViewModel
                {
                    CurrentProduct = product,
                    ProductTypes = _db.ProductTypes,
                    ProductProperties = productProperties
                };
                
                return View(productProperty);
            }  
            else
            {
                return NotFound("Страница не найдена");
            }          
        }

        public IActionResult ViewRoute()
        {
            var controllerName = RouteData.Values["controller"];
            var actionName = RouteData.Values["action"];
            var path = HttpContext.Request.Path;
            return Content($"{controllerName}, {actionName}, path: {path}"); 
        }

        //[HttpGet]
        //public IActionResult AddReview()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return View("/Views/Review/AddReview.cshtml");
        //    }
        //    else
        //    {
        //        return Content("Оставить отзыв могут только авторизированные пользователи.");
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddReview(ReviewViewModel review)
        //{
        //    if(HttpContext.Session.Keys.Contains("UserId"))
        //    {
        //        review.UserId = HttpContext.Session.GetInt32("UserId");
                
        //        await _db.Reviews.AddAsync(review);

        //        await _db.SaveChangesAsync();

        //        return RedirectToAction("PropProduct", new {id = review.ProductId});
        //    }
        //    else
        //    {
        //        return NotFound("Ошибка отправки. Попробуйте позже.");
        //    }
        //}
    }
}
