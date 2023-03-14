using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektKatthem.Data;
using ProjektKatthem.Models;

namespace ProjektKatthem.Controllers
{
    public class AdoptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adopt.Include(a => a.Cats);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adopts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adopt == null)
            {
                return NotFound();
            }

            var adopt = await _context.Adopt
                .Include(a => a.Cats)
                .FirstOrDefaultAsync(m => m.AdoptId == id);
            if (adopt == null)
            {
                return NotFound();
            }

            return View(adopt);
        }

        // GET: Adopts/Create
        public IActionResult Create()
        {
            var catContext = _context.Cats.Where(c => c.Adopted == false)
                .Select(c => c)
                .ToList();

            ViewData["CatsId"] = new SelectList(catContext, "Id", "Name");
            
            return View();
        }

        // POST: Adopts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdoptId,AdoptName,Email,Number,Pickup,CatsId")] Adopt adopt)
        {
            if (ModelState.IsValid)
            {
                //ändrar då adoption bokar katten
                var adoptCat = from s in _context.Cats
                               where s.Id == adopt.CatsId
                               select s;

                foreach (var s in adoptCat)
                {
                    s.Adopted = true;
                }

                _context.Add(adopt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
             

            ViewData["CatsId"] = new SelectList(_context.Cats, "Id", "Name"); 
       
            return View(adopt);
        }

        // GET: Adopts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Adopt == null)
            {
                return NotFound();
            }

            var adopt = await _context.Adopt.FindAsync(id);
            if (adopt == null)
            {
                return NotFound();
            }
            ViewData["CatsId"] = new SelectList(_context.Cats, "Id", "Name", adopt.CatsId);
            return View(adopt);
        }

        // POST: Adopts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdoptId,AdoptName,Email,Number,Pickup,CatsId")] Adopt adopt)
        {
            if (id != adopt.AdoptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptExists(adopt.AdoptId))
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
            ViewData["CatsId"] = new SelectList(_context.Cats, "Id", "Name", adopt.CatsId);
            return View(adopt);
        }

        // GET: Adopts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Adopt == null)
            {
                return NotFound();
            }

            var adopt = await _context.Adopt
                .Include(a => a.Cats)
                .FirstOrDefaultAsync(m => m.AdoptId == id);
            if (adopt == null)
            {
                return NotFound();
            }

            return View(adopt);
        }

        // POST: Adopts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adopt == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Adopt'  is null.");
            }
            var adopt = await _context.Adopt.FindAsync(id);
            if (adopt != null)
            {
                _context.Adopt.Remove(adopt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptExists(int id)
        {
          return (_context.Adopt?.Any(e => e.AdoptId == id)).GetValueOrDefault();
        }
    }
}
