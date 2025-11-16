using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CountryWebApp.Data;
using CountryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CountryWebApp.Controllers
{
    [Authorize] // only for logged-in users
    public class CountriesController : Controller
    {
        private readonly AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    _context.Countries.Add(country);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "Country with this name already exist!");
                }
            }
            return View(country);
        }

        // GET: /Countries/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();
            return View(country);
        }

        // POST: /Countries/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Country country)
        {
            if (id != country.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "Country with this name already exist!");
                }
            }
            return View(country);
        }
    }
}
