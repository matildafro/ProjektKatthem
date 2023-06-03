using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektKatthem.Data;
using ProjektKatthem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ProjektKatthem.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string wwwRootPath;

        public CatsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            wwwRootPath = _hostEnvironment.WebRootPath;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
              return _context.Cats != null ? 
                          View(await _context.Cats.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cats'  is null.");
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cats = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cats == null)
            {
                return NotFound();
            }

            return View(cats);
        }

        [Authorize]
        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,Breed,ImgFile,Adopted,Registered,Info")] Cats cats)
        {
            if (ModelState.IsValid)
            {
                if (cats.ImgFile != null)
                {

                    //Spara bilder till wwwroot
                    string fileName = Path.GetFileNameWithoutExtension(cats.ImgFile.FileName);
                    string extension = Path.GetExtension(cats.ImgFile.FileName);

                    //Plockar bort mellanslag i filnam + lägger till timestamp
                    cats.ImgName = fileName = fileName.Replace(" ", String.Empty) + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/imagesupload", fileName);

                    //Lagra Fil
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await cats.ImgFile.CopyToAsync(fileStream);
                    }


                }
                else
                {
                    cats.ImgFile = null;
                }


                _context.Add(cats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cats);
        }

        [Authorize]
        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cats = await _context.Cats.FindAsync(id);
            if (cats == null)
            {
                return NotFound();
            }
            return View(cats);
        }
        [Authorize]
        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Age,Breed,ImgName,Adopted,Registered,Info")] Cats cats)
        {
            if (id != cats.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)

            {
                try
                {
                    if (cats.ImgFile != null)
                {

                    //Spara bilder till wwwroot
                    string fileName = Path.GetFileNameWithoutExtension(cats.ImgFile.FileName);
                    string extension = Path.GetExtension(cats.ImgFile.FileName);

                    //Plockar bort mellanslag i filnam + lägger till timestamp
                    cats.ImgName = fileName = fileName.Replace(" ", String.Empty) + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/imagesupload", fileName);

                    //Lagra Fil
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await cats.ImgFile.CopyToAsync(fileStream);
                    }


                }
                else
                {
                    if(cats.ImgName != "") {
                        cats.ImgName = cats.ImgName;

                    } else {
                        cats.ImgFile = null;
                    }

                    
                }

                
                    _context.Update(cats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatsExists(cats.Id))
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
            return View(cats);
        }
        [Authorize]
        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cats = await _context.Cats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cats == null)
            {
                return NotFound();
            }

            return View(cats);
        }
        [Authorize]
        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cats'  is null.");
            }
            var cats = await _context.Cats.Include(c => c.Adopt).FirstOrDefaultAsync(m => m.Id == id);
            if (cats != null)
            {
                _context.Cats.Remove(cats);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatsExists(int id)
        {
          return (_context.Cats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
