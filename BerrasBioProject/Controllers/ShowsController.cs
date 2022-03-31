#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;
using BerrasBioProject.Data;
using BerrasBioProject.Services;

namespace BerrasBioProject.Controllers
{
    public class ShowsController : Controller
    {
        private readonly BerrasBioProjectContext _context;

        public ShowsController(BerrasBioProjectContext context)
        {
            _context = context;
            
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            var berrasBioContext = _context.Shows.Include(s => s.Movie).Include(s => s.Salon).Include(s => s.Booking);
            var berrasBioContextList = await berrasBioContext.ToListAsync();

            // Makes shows show the right price
            return View(PriceCalculator.Calculate(berrasBioContextList));
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var shows = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(shows);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");

            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowTime,MovieId,SalonId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shows);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", shows.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", shows.SalonId);

            return View(shows);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var shows = await _context.Shows.FindAsync(id);

            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", shows.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", shows.SalonId);

            return View(shows);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowTime,MovieId,SalonId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shows);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowsExists(shows.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", shows.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", shows.SalonId);

            return View(shows);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var shows = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
 
            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shows = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(shows);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowsExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
