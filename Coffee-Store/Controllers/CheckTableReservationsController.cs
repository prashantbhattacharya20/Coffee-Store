using Coffee_Store.Data;
using Coffee_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Store.Controllers
{
    public class CheckTableReservationsController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public CheckTableReservationsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult CheckTableReservations()
        {
            List<Reservations> obj = _dbContext.Reservations.ToList();
            return View(obj);
        }
    }
}
