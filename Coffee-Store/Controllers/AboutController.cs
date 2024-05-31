using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
