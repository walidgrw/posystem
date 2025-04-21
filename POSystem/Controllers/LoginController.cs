using Microsoft.AspNetCore.Mvc;
using POSystem.Models;

namespace POSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly List<UserRole> _users = new()
        {
            new UserRole { Name = "Manager", Role = "Manager", PinCode = "1111" },
            new UserRole { Name = "Supervisor", Role = "Supervisor", PinCode = "2222" },
            new UserRole { Name = "Staff", Role = "Staff", PinCode = "3333" }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string pin)
        {
            var user = _users.FirstOrDefault(u => u.PinCode == pin);
            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.Name);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid PIN code.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
