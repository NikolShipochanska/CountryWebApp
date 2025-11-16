using CountryWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CountryWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountryWebApp.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Cities/Create
        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(
                _context.Countries.OrderBy(c => c.Name),
                "Id",
                "Name"
            );  

            return View();
        }

        // POST: /Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Cities.Add(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "City with this name already exist!");
                }
            }

            ViewBag.Countries = new SelectList(
                _context.Countries.OrderBy(c => c.Name),
                "Id",
                "Name",
                city.CountryId  
            );

            return View(city);
        }

        // GET: /Cities/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();

            ViewBag.Countries = new SelectList(
                _context.Countries.OrderBy(c => c.Name),
                "Id",
                "Name",
                city.CountryId
            );
            return View(city);
        }

        // POST: /Cities/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("Name", "City with this name already exist!");
                }
            }
            return View(city);
        }
    }
}
