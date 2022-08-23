using ItVis.Models;
using ItVis.DbRepository;
using ItVis.ViewModel;
using ItVis.ViewModel.RegisterModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ItVis.Controllers.Account
{
    public class AccountController : Controller
    {
        private ApplicationContext _db;
        public AccountController(ApplicationContext context) => _db = context;

        [HttpGet]
        public IActionResult Login()
        {
            MainPageViewModel mainPage = new MainPageViewModel
            {
                ProductTypes = _db.ProductTypes.ToList()
            };

            return View("/Views/Account/Login.cshtml", mainPage);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _db.Users.Include(u => u.UserAccount);
                User? user = _db.Users.FirstOrDefault(u => u.UserAccount.Phone == model.Phone && u.UserAccount.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(model.Phone);

                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);

                    return RedirectToAction("Main", "Main");
                }
                else // нужен ли здесь else??
                {
                    ModelState.AddModelError("", "Неверный логин и(или) пароль");
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неверный логин и(или) пароль");
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            MainPageViewModel mainPage = new MainPageViewModel
            {
                ProductTypes = _db.ProductTypes.ToList(),
            };

            return View("/Views/Account/Register.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _db.Users.Include(u => u.UserAccount);
                User? user = await users.FirstOrDefaultAsync(u => u.UserAccount.Phone == model.Phone);

                if (user == null)
                {
                    User newUser = new User(model.Name);

                    await _db.Users.AddAsync(newUser);
                    await _db.SaveChangesAsync();

                    await _db.UsersAccount
                        .AddAsync(new UserAccount { UserId = newUser.Id, Phone = model.Phone, Password = model.Password });
                    await _db.SaveChangesAsync();

                    await Authenticate(model.Phone);

                    HttpContext.Session.SetInt32("UserId", newUser.Id);
                    HttpContext.Session.SetString("UserName", model.Name);

                    return RedirectToAction("Main", "Main");
                }
                else
                {
                    return RedirectToAction("Main", "Main");
                }
            }
            else
            {
                return View("/Views/Account/Register.cshtml");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Clear();

            return RedirectToAction("Main", "Main");
        }

        private async Task Authenticate(string phone)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, phone),
                };

            ClaimsIdentity Id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(Id));
        }
    }
}
