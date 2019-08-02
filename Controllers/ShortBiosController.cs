using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class ShortBiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShortBiosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        private string _getCurrentlyLoggedInUser()
        {
            return _userManager.GetUserId(HttpContext.User);
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
        [Authorize]
        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id !=_getCurrentlyLoggedInUser())
            {
                // Route user to authorized page if request id is invalid
                id = _getCurrentlyLoggedInUser();
            }
            
            var shortBio = await _context.ShortBios.FindAsync(id);
            
            TextInfo caseTitle = new CultureInfo("en-US",false).TextInfo;
            ViewBag.loggedInUserName = caseTitle.ToTitleCase(_userManager.GetUserName(HttpContext.User));
            ViewBag.loggedInUserId = _userManager.GetUserId(HttpContext.User);
            
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
        public JsonResult Edit(string id, [Bind("DeveloperId,ShortDescription,CurrentCity,IsAvailableForJob")] ShortBio shortBio)
        {
            if (id != shortBio.DeveloperId)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shortBio);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShortBioExists(shortBio.DeveloperId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(shortBio);
            }
            return null;
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
