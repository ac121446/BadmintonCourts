﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BadmintonCourts.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;


        public BookingsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        [Authorize]

        // GET: Bookings
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IQueryable<Booking> bookings = _context.Bookings
                .Include(b => b.BadmintonCourtsUser)
                .Include(b => b.Court)
                .Include(b => b.Equipment);

            if (!User.IsInRole("Admin"))
            {
                //Filter bookings for non-admin users to only see their own bookings
                bookings = bookings.Where(b => b.BadmintonCourtsUserId == userId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(b =>
                    b.BadmintonCourtsUser.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    bookings = bookings.OrderByDescending(s => s.BookingDate);
                    break;
                default:
                    bookings = bookings.OrderBy(s => s.BookingDate);
                    break;
            }
            int pageSize = 10;

            return View(await PaginatedList<Booking>.CreateAsync(bookings.AsNoTracking(), pageNumber ?? 1, pageSize));
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
            ViewData["BadmintonCourtsUserId"] = new SelectList(_context.Users, "Id", "Id");
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
