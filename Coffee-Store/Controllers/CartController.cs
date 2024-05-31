using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Coffee_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public CartController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Display the Cart
        public IActionResult Cart()
        {
            try
            {
                // Retrieve the username from the session
                var username = HttpContext.Session.GetString("username");
                if (username == null)
                {
                    // If the user is not logged in, return an empty cart
                    return View(new List<CartItem>());
                }

                // Find the user in the database
                var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
                if (user == null)
                {
                    // If the user does not exist, return an empty cart
                    return View(new List<CartItem>());
                }

                // Find the user's cart in the database
                var cart = _dbContext.Cart.SingleOrDefault(c => c.UserID == user.UserID);
                if (cart == null)
                {
                    // If the cart does not exist, return an empty cart
                    return View(new List<CartItem>());
                }

                // Retrieve the items in the cart
                var cartItems = _dbContext.CartItem
                    .Where(ci => ci.CartID == cart.CartID)
                    .Include(ci => ci.Menu)
                    .ToList();
                return View(cartItems);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        // Action to clear the cart
        [HttpPost]
        public IActionResult ClearCart()
        {
            try
            {
                // Retrieve the username from the session
                var username = HttpContext.Session.GetString("username");
                // Find the user in the database
                var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);

                if (user != null)
                {
                    // Find the user's cart in the database
                    var cart = _dbContext.Cart.SingleOrDefault(c => c.UserID == user.UserID);

                    if (cart != null)
                    {
                        // Retrieve the items in the cart
                        var cartItems = _dbContext.CartItem.Where(ci => ci.CartID == cart.CartID);

                        // Remove the items from the cart
                        _dbContext.CartItem.RemoveRange(cartItems);
                        _dbContext.SaveChanges();

                        // Set a success message
                        TempData["success"] = "Cart cleared successfully.";
                        return RedirectToAction("Cart", "Cart");
                    }

                    // If the cart does not exist, return a not found error
                    return NotFound("No cart found for the user.");
                }

                // If the user is not logged in, return an unauthorized error
                return Unauthorized("Please log in to clear the cart.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}