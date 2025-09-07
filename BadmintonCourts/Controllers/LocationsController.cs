using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonCourts.Controllers
{
    public class LocationsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public LocationsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        // GET: Locations list with search, sort, and pagination
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            ViewData["DateSortParm"] = sortOrder == "City" ? "city_desc" : "city";
            ViewData["CurrentFilter"] = searchString;

            var locations = from l in _context.Locations select l;

            // Filter by search string
            if (!String.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(l => l.LocationName.Contains(searchString) ||
                                                 l.Addresss.Contains(searchString) ||
                                                 l.City.Contains(searchString));
            }

            // Sorting logic
            switch (sortOrder)
            {
                case "name_desc":
                    locations = locations.OrderByDescending(l => l.LocationName);
                    break;
                case "city":
                    locations = locations.OrderBy(l => l.City);
                    break;
                case "city_desc":
                    locations = locations.OrderByDescending(l => l.City);
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

        // GET: Location details by ID
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

        // GET: Create new location (Admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create new location (Admin only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationsID,LocationName,Addresss,Suburb,City,PostalCode,PhoneNumber")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Edit location (Admin only)
        [Authorize(Roles = "Admin")]
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

        // POST: Save edited location (Admin only)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("LocationsID,LocationName,Addresss,Suburb,City,PostalCode,PhoneNumber")] Location location)
        {
            if (id != location.LocationsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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

        // GET: Delete location confirmation (Admin only)
        [Authorize(Roles = "Admin")]
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

        // POST: Confirm delete location (Admin only)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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

        // Check if location exists
        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationsID == id);
        }

        // API: Get matching locations for autocomplete
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
