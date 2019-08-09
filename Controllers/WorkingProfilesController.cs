using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class WorkingProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WorkingProfilesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        private string _getCurrentlyLoggedInUser()
        {
            return _userManager.GetUserId(HttpContext.User);
        }

        // GET: WorkingProfiles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id !=_getCurrentlyLoggedInUser())
            {
                return NotFound();
            }

            var workingProfile = await _context.WorkingProfiles.FindAsync(id);
            TextInfo caseTitle = new CultureInfo("en-US",false).TextInfo;
            ViewBag.loggedInUserName = caseTitle.ToTitleCase(_userManager.GetUserName(HttpContext.User));
            ViewBag.loggedInUserId = _userManager.GetUserId(HttpContext.User);
            
            if (workingProfile == null)
            {
                return NotFound();
            }
            return View(workingProfile);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(string id, [Bind("DeveloperId,GithubUsername,PrivacyForGithub,CodeforcesUsername,PrivacyForCodeforces,UhuntUsername,PrivacyForUhunt")] WorkingProfile workingProfile)
        {
            if (id != workingProfile.DeveloperId)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingProfile);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingProfileExists(workingProfile.DeveloperId))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(workingProfile);
            }
            return null;
        }

        private bool WorkingProfileExists(string id)
        {
            return _context.WorkingProfiles.Any(e => e.DeveloperId == id);
        }
    }
}
