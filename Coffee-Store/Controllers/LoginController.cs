using Coffee_Store.Data;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _context;

        public LoginController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                // Attempt to find a user in the database that matches the provided username and password
                var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // If a matching user is found, store the username in the session
                    HttpContext.Session.SetString("username", username);
                    // Redirect the user to the Home page
                    return RedirectToAction("Index", "Home");
                }

                // If no matching user is found, set an error message in TempData
                TempData["Error"] = "Invalid username or password";
                return View();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IActionResult Logout()
        {
            // Clear all keys and values from the session
            HttpContext.Session.Clear();
            // Redirect the user to the Login page
            return RedirectToAction("Login", "Login");
        }
    }
}
