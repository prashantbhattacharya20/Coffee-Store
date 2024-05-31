using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class SignupController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public SignupController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost, ActionName("Signup")]
        public IActionResult Signup(User obj)
        {
            try
            {
                // Check if the model state is valid
                if (ModelState.IsValid)
                {
                    // Add the user to the database
                    _dbContext.Users.Add(obj);
                    _dbContext.SaveChanges();

                    // Set a success message
                    TempData["success"] = "New User Created Successfully.";

                    // Redirect to the login page
                    return RedirectToAction("Login", "Login");
                }
                // If the model state is not valid, re-render the signup view
                return View();

            } catch (Exception ex) 
            { 
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
