using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonCourts.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public EquipmentsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Equipments list with search, sort, and pagination
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "ename_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;  // Reset to first page when search changes
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // Base query for equipments
            var equipments = from e in _context.Equipments
                             select e;

            // Apply search filter
            if (!String.IsNullOrEmpty(searchString))
            {
                equipments = equipments.Where(e => e.EName.Contains(searchString));
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "ename_desc":
                    equipments = equipments.OrderByDescending(e => e.EName);
                    break;
                default:
                    equipments = equipments.OrderBy(e => e.EName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Equipment>.CreateAsync(equipments.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Equipment details by ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(m => m.EquipmentID == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Create equipment form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Save new equipment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentID,EName,EType,EPrice")] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Edit equipment form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Save edited equipment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentID,EName,EType,EPrice")] Equipment equipment)
        {
            if (id != equipment.EquipmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.EquipmentID))
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
            return View(equipment);
        }

        // GET: Delete confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(m => m.EquipmentID == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Confirm delete equipment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if equipment exists
        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.EquipmentID == id);
        }
    }
}
