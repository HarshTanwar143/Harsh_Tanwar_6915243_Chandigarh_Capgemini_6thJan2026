using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in, go straight to dashboard
            if (HttpContext.Session.GetString("Username") != null)
                return RedirectToAction("Dashboard");

            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // ✅ Check credentials
                if (model.Username == "admin" && model.Password == "123")
                {
                    // ✅ Save username in Session
                    HttpContext.Session.SetString("Username", model.Username);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Error = "❌ Invalid username or password!";
                }
            }

            return View(model);
        }

        // GET: /Account/Dashboard
        public IActionResult Dashboard()
        {
            // ✅ If not logged in, redirect back to Login
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
                return RedirectToAction("Login");

            ViewBag.Username = username;
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // ✅ Clear the session and redirect to Login
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}