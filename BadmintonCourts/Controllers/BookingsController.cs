using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using System.Security.Claims;

namespace BadmintonCourts.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public BookingsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var badmintonCourtsDbContext = _context.Bookings.Include(b => b.BadmintonCourtsUser).Include(b => b.Court).Include(b => b.Equipment);
            return View(await badmintonCourtsDbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.BadmintonCourtsUser)
                .Include(b => b.Court)
                .Include(b => b.Equipment)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["BadmintonCourtsUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["CourtID"] = new SelectList(_context.Courts, "CourtID", "CourtName");
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentID", "EName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,BadmintonCourtsUserId,CourtID,EquipmentID,BookingDate,StartTime,EndTime,TotalPrice")] Booking booking)
        {

            if (!User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  //Get current user id.
                booking.BadmintonCourtsUserId = userId;  //Automatically assign current user id to the booking.
            }
            
            if (!ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BadmintonCourtsUserId"] = new SelectList(_context.Users, "Id", "FirstName", booking.BadmintonCourtsUserId);
            ViewData["CourtID"] = new SelectList(_context.Courts, "CourtID", "CourtName", booking.CourtID);
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentID", "EName", booking.EquipmentID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["BadmintonCourtsUserId"] = new SelectList(_context.Users, "Id", "Id", booking.BadmintonCourtsUserId);
            ViewData["CourtID"] = new SelectList(_context.Courts, "CourtID", "CourtName", booking.CourtID);
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentID", "EName", booking.EquipmentID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,BadmintonCourtsUserId,CourtID,EquipmentID,BookingDate,StartTime,EndTime,TotalPrice")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["BadmintonCourtsUserId"] = new SelectList(_context.Users, "Id", "Id", booking.BadmintonCourtsUserId);
            ViewData["CourtID"] = new SelectList(_context.Courts, "CourtID", "CourtName", booking.CourtID);
            ViewData["EquipmentID"] = new SelectList(_context.Equipments, "EquipmentID", "EName", booking.EquipmentID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.BadmintonCourtsUser)
                .Include(b => b.Court)
                .Include(b => b.Equipment)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }
    }
}
