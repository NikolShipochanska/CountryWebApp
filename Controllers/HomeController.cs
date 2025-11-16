using System.Diagnostics;
using CountryWebApp.Data;
using CountryWebApp.Helpers;
using CountryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 3;
            var countries = _context.Countries
                .Include(c => c.Cities)
                .AsNoTracking()
                .OrderBy(c => c.Name);

            var paginated = await PaginatedList<Country>.CreateAsync(countries, pageNumber ?? 1, pageSize);
            return View(paginated);
        }
    }
}
