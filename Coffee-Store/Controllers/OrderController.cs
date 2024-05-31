using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public OrderController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Order()
        {
            try
            {
                // Check if the user is logged in
                if (HttpContext.Session.GetString("username") == null)
                {
                    // Redirect to the login page if the user is not logged in
                    return RedirectToAction("Login", "Login");
                }

                // Retrieve all menu items from the database
                List<Menu> obj = _dbContext.Menu.ToList();
                // Return the menu items to the view
                return View(obj);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddToCart(int itemId, int quantity)
        {
            try
            {
                // Validate the quantity
                if (quantity <= 0 || quantity > 99)
                {
                    TempData["error"] = "Quantity must be between 1 and 99.";
                    return RedirectToAction("Order", "Order");
                }

                // Retrieve the username from the session
                var username = HttpContext.Session.GetString("username");
                // Find the user in the database
                var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);

                if (user != null)
                {
                    // Find the user's cart in the database
                    var cart = _dbContext.Cart.SingleOrDefault(c => c.UserID == user.UserID);

                    if (cart == null)
                    {
                        // Create a new cart for the user if it doesn't exist
                        cart = new Cart { UserID = user.UserID };
                        _dbContext.Cart.Add(cart);
                        _dbContext.SaveChanges();
                    }

                    // Check if the item already exists in the cart
                    var existingCartItem = _dbContext.CartItem.SingleOrDefault(ci => ci.CartID == cart.CartID && ci.ItemID == itemId);

                    if (existingCartItem != null)
                    {
                        // If the item exists, update the quantity
                        existingCartItem.Quantity += quantity;
                    }
                    else
                    {
                        // If the item does not exist, create a new cart item
                        var cartItem = new CartItem
                        {
                            CartID = cart.CartID,
                            ItemID = itemId,
                            Quantity = quantity
                        };

                        // Add the cart item to the database
                        _dbContext.CartItem.Add(cartItem);
                    }

                    _dbContext.SaveChanges();
                    // Set a flag to show the alert
                    TempData["showAlert"] = true;
                    return RedirectToAction("Order", "Order");
                }
                // Return an unauthorized error if the user is not logged in
                return Unauthorized("Please log in to add items to cart.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}