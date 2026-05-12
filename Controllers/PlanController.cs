using GymSystem.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Controllers
{
    public class PlanController(GYMDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var plan = await context.Plans.ToListAsync();

            return View(plan);
        }

        public async Task<IActionResult> Details(int id)
        {
            var plan = await context.Plans.FirstOrDefaultAsync(p => p.Id == id);

            if (plan == null) { return RedirectToAction(nameof(Index)); }
              
            return View(plan);
        }
    }
}
