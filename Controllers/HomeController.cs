using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(IFormCollection formFields)
        {
            List<Object> objectList = new List<object>();
            var developerId = _userManager.FindByNameAsync(formFields["developerUsername"]).Result.Id;
            var shortBios = _context.ShortBios.FindAsync(developerId);
            var workingProfile = _context.WorkingProfiles.FindAsync(developerId);
            
            objectList.Add(developerId);
            objectList.Add(shortBios);
            objectList.Add(workingProfile);
            
            return Json(objectList);
        }
        
        [HttpGet("Home/Dev/{username}")]
        public async Task<IActionResult> Dev(string username)
        {
            var developerId = _userManager.FindByNameAsync(username).Result.Id;
            return Ok(developerId);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}