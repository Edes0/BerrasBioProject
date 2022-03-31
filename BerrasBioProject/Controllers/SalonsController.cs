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
    public class SalonsController : Controller
    {
        private readonly BerrasBioProjectContext _context;

        public SalonsController(BerrasBioProjectContext context)
        {
            _context = context;
        }

        // GET: Salons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salons.ToListAsync());
        }

        // GET: Salons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salons = await _context.Salons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salons == null)
            {
                return NotFound();
            }

            return View(salons);
        }

        // GET: Salons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Seats")] Salons salons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salons);
        }

        // GET: Salons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salons = await _context.Salons.FindAsync(id);
            if (salons == null)
            {
                return NotFound();
            }
            return View(salons);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Seats")] Salons salons)
        {
            if (id != salons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonsExists(salons.Id))
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
            return View(salons);
        }

        // GET: Salons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salons = await _context.Salons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salons == null)
            {
                return NotFound();
            }

            return View(salons);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salons = await _context.Salons.FindAsync(id);
            _context.Salons.Remove(salons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonsExists(int id)
        {
            return _context.Salons.Any(e => e.Id == id);
        }
    }
}
