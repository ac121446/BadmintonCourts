using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.Extensions.Options;

namespace BadmintonCourts.Controllers
{
    public class LocationsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public LocationsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Addresss" ? "addresss_desc" : "Addresss";
            ViewData["CurrentFilter"] = searchString;
            var locations = from l in _context.Locations
                           select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(l => l.LocationName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    locations = locations.OrderByDescending(l => l.LocationName);
                    break;
                case "Addresss":
                    locations = locations.OrderBy(l => l.Addresss);
                    break;
                case "addresss_desc":
                    locations = locations.OrderByDescending(l => l.Addresss);
                    break;
                default:
                    locations = locations.OrderBy(l => l.LocationName);
                    break;
            }

            ViewData["CurrentSort"] = sortOrder; 
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            int pageSize = 10;
            return View(await PaginatedList<Location>.CreateAsync(locations.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationsID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationsID,LocationName,Addresss,Suburb,City,PostalCode,PhoneNumber")] Location location)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationsID,LocationName,Addresss,Suburb,City,PostalCode,PhoneNumber")] Location location)
        {
            if (id != location.LocationsID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationsID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationsID == id);
        }

        [HttpGet]
        public JsonResult GetMatchingLocations(string term)
        {
            var matches = _context.Locations
                .Where(l => l.LocationName.Contains(term))
                .Select(l => l.LocationName)
                .Take(10)
                .ToList();

            return Json(matches);
        }
    }
}
