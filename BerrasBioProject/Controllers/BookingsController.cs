#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;
using BerrasBioProject.Data;

namespace BerrasBioProject.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BerrasBioProjectContext _context;

        public BookingsController(BerrasBioProjectContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var berrasBioProjectContext = _context.Bookings
                .Include(b => b.Show)
                .ThenInclude(b => b.Movie);

            return View(await berrasBioProjectContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var bookings = await _context.Bookings
                .Include(b => b.Show)
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(bookings);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create(int id)
        {
            Bookings booking = new Bookings();

            booking = await _context.Bookings
                .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
                .Include(b => b.Show)
                .ThenInclude(s => s.Salon)
                .Include(b => b.Show)
                .FirstOrDefaultAsync(b => b.Show.Id == id);

            return View(booking);
        }
        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowId,NumOfSeats")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                var show = _context.Shows
                    .Include(s => s.Movie)
                    .Single(Show => Show.Id == bookings.ShowId);

                bookings.Total = show.Movie.Price * bookings.NumOfSeats;
                show.SeatsTaken += bookings.NumOfSeats;

                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["ShowId"] = new SelectList(_context.Set<Shows>(), "Id", "Id", bookings.ShowId);
            return View(bookings);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Set<Shows>(), "Id", "Id", bookings.ShowId);
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId,NumOfSeats")] Bookings bookings)
        {
            if (id != bookings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.Id))
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
            ViewData["ShowId"] = new SelectList(_context.Set<Shows>(), "Id", "Id", bookings.ShowId);
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bookings = await _context.Bookings
                .Include(b => b.Show)
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.Include(s => s.Show).FirstOrDefaultAsync(Bookings => Bookings.Id == id);

            //Removes seats
            bookings.Show.SeatsTaken -= bookings.NumOfSeats;

            _context.Bookings.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
