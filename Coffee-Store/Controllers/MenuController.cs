using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public MenuController(ApplicationDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public IActionResult Menu()
        {
            try
            {
                // Retrieve all menu items from the database
                List<Menu> obj = _dbContext.Menu.ToList();

                // Return the menu items to the view
                return View(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
