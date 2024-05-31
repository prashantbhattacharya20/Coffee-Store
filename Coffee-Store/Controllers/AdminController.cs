using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public AdminController(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        // Display the admin view with the list of menu items
        public IActionResult Admin()
        {
            try
            {
                List<Menu> obj = _applicationDBContext.Menu.ToList();
                return View(obj);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // Display the form for adding a new menu item
        public IActionResult AddNewMenuItem() 
        {
            return View();        
        }

        // Action to handle the post request when adding a new menu item
        [HttpPost, ActionName("AddNewMenuItem")]
        public IActionResult AddNewMenuItem(Menu obj) 
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _applicationDBContext.Menu.Add(obj);
                    _applicationDBContext.SaveChanges();
                    return RedirectToAction("Admin", "Admin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return View();
        }

        // Action to display the form for editing a menu item
        public IActionResult EditMenuItem(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
                try
            {
                // Find the menu item in the database using the Id
                Menu indexData = _applicationDBContext.Menu.Find(Id);
                // If the menu item is found, return the view with the menu item data
                if(indexData != null) { return View(indexData); }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // If the menu item is not found, return a NotFound result
            return NotFound();
        }


        // Action to handle the post request when editing a menu item
        [HttpPost, ActionName("EditMenuItem")]
        public IActionResult EditMenuItem(Menu obj) 
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Update the menu item in the database
                    _applicationDBContext.Menu.Update(obj);
                    _applicationDBContext.SaveChanges();

                    // Redirect to the Admin action
                    return RedirectToAction("Admin", "Admin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            return View();
        }

        // Action to display the form for deleting a menu item
        public IActionResult DeleteMenuItem(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            try
            {
                // Find the menu item in the database using the Id
                Menu indexData = _applicationDBContext.Menu.Find(Id);
                // If the menu item is found, return the view with the menu item data
                if (indexData != null) { return View(indexData); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                throw;
            }
            // If the menu item is not found, return a NotFound result
            return NotFound();
        }

        // Action to handle the post request when deleting a menu item
        [HttpPost, ActionName("DeleteMenuItem")]
        public IActionResult DeleteMenuItem(Menu obj)
        {
            try
            {
                // Find the menu item in the database using the ItemID
                var menuItem = _applicationDBContext.Menu.Find(obj.ItemID);
                // If the menu item is found
                if (menuItem != null)
                {
                    // Remove the menu item from the database
                    _applicationDBContext.Menu.Remove(menuItem);
                    _applicationDBContext.SaveChanges();

                    // Redirect to the Admin action
                    return RedirectToAction("Admin", "Admin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // If the menu item is not found, return the view with the current data
            return View(obj);
        }
    }
}
