using BadmintonCourts.Areas.Identity.Data;
using BadmintonCourts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BadmintonCourts.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly BadmintonCourtsDbContext _context;

        public PaymentsController(BadmintonCourtsDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Payments list with search, sort, and pagination
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;

            // Sorting buttons for amount
            ViewData["AmountSortParm"] = sortOrder == "amount_asc" ? "amount_desc" : "amount_asc";

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

            // Include bookings and related users
            IQueryable<Payment> payments = _context.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.BadmintonCourtsUser);

            // Filter by user's first name
            if (!string.IsNullOrEmpty(searchString))
            {
                payments = payments.Where(p => p.Booking.BadmintonCourtsUser.FirstName.Contains(searchString));
            }

            // Sorting logic
            payments = sortOrder switch
            {
                "amount_asc" => payments.OrderBy(p => p.PaymentAmount),
                "amount_desc" => payments.OrderByDescending(p => p.PaymentAmount),
                _ => payments.OrderBy(p => p.PaymentDate), // Default by date
            };

            int pageSize = 10;
            return View(await PaginatedList<Payment>.CreateAsync(payments.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Payment details by ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Create new payment
        public IActionResult Create()
        {
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BadmintonCourtsUserId");
            return View();
        }

        // POST: Save new payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,BookingID,PaymentAmount,PaymentDate,PaymentStatus")] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BadmintonCourtsUserId", payment.BookingID);
            return View(payment);
        }

        // GET: Edit existing payment
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BadmintonCourtsUserId", payment.BookingID);
            return View(payment);
        }

        // POST: Save edited payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,BookingID,PaymentAmount,PaymentDate,PaymentStatus")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
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
            ViewData["BookingID"] = new SelectList(_context.Bookings, "BookingID", "BadmintonCourtsUserId", payment.BookingID);
            return View(payment);
        }

        // GET: Delete confirmation page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Confirm delete payment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Check if payment exists
        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
