using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class ShortBiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShortBiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShortBios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShortBios.ToListAsync());
        }

        // GET: ShortBios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortBio = await _context.ShortBios
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (shortBio == null)
            {
                return NotFound();
            }

            return View(shortBio);
        }

        // GET: ShortBios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShortBios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeveloperId,ShortDescription,CurrentCity,IsAvailableForJob")] ShortBio shortBio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shortBio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shortBio);
        }

        // GET: ShortBios/Edit/5
        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortBio = await _context.ShortBios.FindAsync(id);
            if (shortBio == null)
            {
                return NotFound();
            }
            return View(shortBio);
        }

        // POST: ShortBios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DeveloperId,ShortDescription,CurrentCity,IsAvailableForJob")] ShortBio shortBio)
        {
            if (id != shortBio.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shortBio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShortBioExists(shortBio.DeveloperId))
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
            return View(shortBio);
        }

        // GET: ShortBios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shortBio = await _context.ShortBios
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (shortBio == null)
            {
                return NotFound();
            }

            return View(shortBio);
        }

        // POST: ShortBios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shortBio = await _context.ShortBios.FindAsync(id);
            _context.ShortBios.Remove(shortBio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShortBioExists(string id)
        {
            return _context.ShortBios.Any(e => e.DeveloperId == id);
        }
    }
}
