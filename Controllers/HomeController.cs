using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HashSet<Object> _objectList;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _objectList = new HashSet<object>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(IFormCollection formFields)
        {
            var developerId = "";
            try
            {
                developerId = _userManager.FindByNameAsync(formFields["developerUsername"]).Result.Id;
                
                var shortBios = _context.ShortBios.Single(x => x.DeveloperId == developerId);
                
                var workingProfile = _context.WorkingProfiles.Single(x => x.DeveloperId == developerId);
                workingProfile.CodeforcesUsername = workingProfile.PrivacyForCodeforces ? null : workingProfile.CodeforcesUsername;
                workingProfile.GithubUsername = workingProfile.PrivacyForGithub ? null : workingProfile.GithubUsername;
                workingProfile.UhuntUsername = workingProfile.PrivacyForUhunt ? null : workingProfile.UhuntUsername;
                
                _objectList.Add(shortBios);
                _objectList.Add(workingProfile);
                return Json(_objectList);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        
        [HttpGet("Home/Dev/{username}")]
        public IActionResult Dev(string username)
        {
            var developerId = _userManager.FindByNameAsync(username).Result.Id;
            var shortBios = _context.ShortBios.FindAsync(developerId);
            return Ok(shortBios);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpPost("Home/Audit")]
        public async Task<JsonResult> Audit(AuditLogging jObject)
        {
            if (jObject != null)
            {
                _context.Add(jObject);
                await _context.SaveChangesAsync();
            }
            var audit = _context.Set<AuditLogging>().Select(x => new
            {
                x.Country,
                x.CountryCode,
                x.TimeOfAction
            });
                
            return Json(audit);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}