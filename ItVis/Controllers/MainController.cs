using ItVis.ViewModel;
using ItVis.DbRepository;
using Microsoft.AspNetCore.Mvc;

namespace ItVis.Controllers
{
    public class MainController : Controller
    {
        private ApplicationContext _db;
        public MainController(ApplicationContext context) => _db = context;

        public IActionResult Main()
        {
            MainPageViewModel mainPage = new MainPageViewModel
            {
                ProductTypes = _db.ProductTypes
            };
            
            return View(mainPage);
        }
    }
}