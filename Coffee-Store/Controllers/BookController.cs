using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public BookController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Book()
        {
            return View();
        }

        [HttpPost, ActionName("Book")]
        public IActionResult Book(Reservations obj)
        {
            try
            {
                // Check if the model state is valid
                if (ModelState.IsValid)
                {
                    // Add the reservation to the database
                    _dbContext.Reservations.Add(obj);
                    _dbContext.SaveChanges();

                    // Set a success message
                    TempData["success"] = "Table Reservation Made Successfully.";

                    // Redirect to the home page
                    return RedirectToAction("Index", "Home");
                }

                // If the model state is not valid, re-render the booking view
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
