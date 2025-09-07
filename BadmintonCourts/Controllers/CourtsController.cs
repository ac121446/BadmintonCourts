using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonCourts.Controllers
{
    public class CourtsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public CourtsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Courts list with search, sort, and pagination
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // Load courts with related location data
            var courts = _context.Courts
                                 .Include(e => e.Location)
                                 .AsQueryable();

            // Apply search filter
            if (!String.IsNullOrEmpty(searchString))
            {
                courts = courts.Where(e => e.CourtName.Contains(searchString));
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "name_desc":
                    courts = courts.OrderByDescending(e => e.CourtName);
                    break;
                default:
                    courts = courts.OrderBy(e => e.CourtName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Court>.CreateAsync(courts.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Court details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Get court with location info
            var court = await _context.Courts
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.CourtID == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // GET: Create court form
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationsID", "Addresss");
            return View();
        }

        // POST: Save new court
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourtID,LocationID,CourtName,Price")] Court court)
        {
            if (ModelState.IsValid)
            {
                _context.Add(court);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Reload dropdown if validation fails
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationsID", "Addresss", court.LocationID);
            return View(court);
        }

        // GET: Edit court form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts.FindAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationsID", "Addresss", court.LocationID);
            return View(court);
        }

        // POST: Save edited court
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourtID,LocationID,CourtName,Price")] Court court)
        {
            if (id != court.CourtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(court);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourtExists(court.CourtID))
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
            // Reload dropdown if validation fails
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationsID", "Addresss", court.LocationID);
            return View(court);
        }

        // GET: Delete confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var court = await _context.Courts
                .Include(c => c.Location)
                .FirstOrDefaultAsync(m => m.CourtID == id);
            if (court == null)
            {
                return NotFound();
            }

            return View(court);
        }

        // POST: Confirm delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var court = await _context.Courts.FindAsync(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if court exists
        private bool CourtExists(int id)
        {
            return _context.Courts.Any(e => e.CourtID == id);
        }
    }
}
