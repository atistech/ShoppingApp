using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using ShoppingApp.EntitiesLayer;
using ShoppingApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private UserBLL _userBLL = new UserBLL();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            User current = _userBLL.Login(vm.UserName);
            if (current != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, current.ID.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("List", "Product");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("List", "Product");
        }

        [HttpGet]
        public ActionResult GetCurrentUser()
        {
            var userIdentity = (ClaimsIdentity)User.Identity;
            if (userIdentity.Name != null)
            {
                User u = _userBLL.GetUserByID(new Guid(userIdentity.Name));
                if (u != null)
                    return Json(new {
                        identity = true,
                        name = u.FirstName + " " + u.LastName
                    });
            }

            return Json(new
            {
                identity = false
            });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            User user = new User();
            user.ID = new Guid();
            user.UserName = vm.UserName;
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Age = vm.Age;
            _userBLL.Register(user);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.ID.ToString())
            };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return RedirectToAction("List", "Product");
        }


    }
}
