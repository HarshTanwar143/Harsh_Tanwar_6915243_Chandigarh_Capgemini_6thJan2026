using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") != null)
                return RedirectToAction("Dashboard");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "123")
                {
                    HttpContext.Session.SetString("Username", model.Username);
                    return RedirectToAction("Dashboard");
                }
                ViewBag.Error = "❌ Invalid username or password!";
            }
            return View(model);
        }

        public IActionResult Dashboard()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login");

            ViewBag.Username = username;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}