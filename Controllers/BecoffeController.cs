using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBecoffe.Models;

namespace MyBecoffe.Controllers
{
    public class BecoffeController : Controller
    {
        private readonly MyBecoffeContext _context;

        public BecoffeController(MyBecoffeContext context)
        {
            _context = context;
        }

        // GET: Becoffe
        public async Task<IActionResult> Index()
        {
              return _context.Becoffe != null ? 
                          View(await _context.Becoffe.ToListAsync()) :
                          Problem("Entity set 'MyBecoffeContext.Becoffe'  is null.");
        }

        // GET: Becoffe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Becoffe == null)
            {
                return NotFound();
            }

            var becoffe = await _context.Becoffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (becoffe == null)
            {
                return NotFound();
            }

            return View(becoffe);
        }

        // GET: Becoffe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Becoffe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,email,password,account_type")] Becoffe becoffe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(becoffe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(becoffe);
        }

        // GET: Becoffe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Becoffe == null)
            {
                return NotFound();
            }

            var becoffe = await _context.Becoffe.FindAsync(id);
            if (becoffe == null)
            {
                return NotFound();
            }
            return View(becoffe);
        }

        // POST: Becoffe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,email,password,account_type")] Becoffe becoffe)
        {
            if (id != becoffe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(becoffe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BecoffeExists(becoffe.Id))
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
            return View(becoffe);
        }

        // GET: Becoffe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Becoffe == null)
            {
                return NotFound();
            }

            var becoffe = await _context.Becoffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (becoffe == null)
            {
                return NotFound();
            }

            return View(becoffe);
        }

        // POST: Becoffe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Becoffe == null)
            {
                return Problem("Entity set 'MyBecoffeContext.Becoffe'  is null.");
            }
            var becoffe = await _context.Becoffe.FindAsync(id);
            if (becoffe != null)
            {
                _context.Becoffe.Remove(becoffe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BecoffeExists(int id)
        {
          return (_context.Becoffe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
