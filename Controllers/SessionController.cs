using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Username", "Ivan Ivanov");
            return Content("Сесията беше създадена успешно!");
        }
        public IActionResult GetSession()
        {
            var username= HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return Content("Няма запазена сесийна стойност.");
            }
            return Content($"Съхранението има в сесията: {username}");
        }
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("Сесията беше изчистена.");
        }
        public IActionResult TimeSession()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return Content("Сесията ви е изтекла.");
            }
            return Content($"Сесията е активна: {username}");
        }
    }
}
