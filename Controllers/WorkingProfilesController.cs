using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class WorkingProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkingProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkingProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkingProfiles.ToListAsync());
        }

        // GET: WorkingProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingProfile = await _context.WorkingProfiles
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (workingProfile == null)
            {
                return NotFound();
            }

            return View(workingProfile);
        }

        // GET: WorkingProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeveloperId,GithubUsername,PrivacyForGithub,CodeforcesUsername,PrivacyForCodeforces,UhuntUsername,PrivacyForUhunt")] WorkingProfile workingProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingProfile);
        }

        // GET: WorkingProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingProfile = await _context.WorkingProfiles.FindAsync(id);
            if (workingProfile == null)
            {
                return NotFound();
            }
            return View(workingProfile);
        }

        // POST: WorkingProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DeveloperId,GithubUsername,PrivacyForGithub,CodeforcesUsername,PrivacyForCodeforces,UhuntUsername,PrivacyForUhunt")] WorkingProfile workingProfile)
        {
            if (id != workingProfile.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingProfileExists(workingProfile.DeveloperId))
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
            return View(workingProfile);
        }

        // GET: WorkingProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingProfile = await _context.WorkingProfiles
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (workingProfile == null)
            {
                return NotFound();
            }

            return View(workingProfile);
        }

        // POST: WorkingProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workingProfile = await _context.WorkingProfiles.FindAsync(id);
            _context.WorkingProfiles.Remove(workingProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingProfileExists(string id)
        {
            return _context.WorkingProfiles.Any(e => e.DeveloperId == id);
        }
    }
}
