using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class SocialProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialProfiles.ToListAsync());
        }

        // GET: SocialProfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialProfile = await _context.SocialProfiles
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (socialProfile == null)
            {
                return NotFound();
            }

            return View(socialProfile);
        }

        // GET: SocialProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeveloperId,LinkedInUsername,FacebookUsername,TwitterUsername")] SocialProfile socialProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialProfile);
        }

        // GET: SocialProfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialProfile = await _context.SocialProfiles.FindAsync(id);
            if (socialProfile == null)
            {
                return NotFound();
            }
            return View(socialProfile);
        }

        // POST: SocialProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DeveloperId,LinkedInUsername,FacebookUsername,TwitterUsername")] SocialProfile socialProfile)
        {
            if (id != socialProfile.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialProfileExists(socialProfile.DeveloperId))
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
            return View(socialProfile);
        }

        // GET: SocialProfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialProfile = await _context.SocialProfiles
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (socialProfile == null)
            {
                return NotFound();
            }

            return View(socialProfile);
        }

        // POST: SocialProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var socialProfile = await _context.SocialProfiles.FindAsync(id);
            _context.SocialProfiles.Remove(socialProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialProfileExists(string id)
        {
            return _context.SocialProfiles.Any(e => e.DeveloperId == id);
        }
    }
}
