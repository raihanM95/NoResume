using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        
        private void AddJson(Object obj)
        {
            _objectList.Add(obj);
        }

        private string TitleCase(string str)
        {
            TextInfo caseTitle = new CultureInfo("en-US",false).TextInfo;
            return caseTitle.ToTitleCase(str);
        }
        
        public async Task<IActionResult> Index()
        {
            var jsonFetch = new WebClient().DownloadString("https://geoip-db.com/json/");
            JObject jObject = JObject.Parse(jsonFetch);
            
            var audit = new AuditLogging
            {
                AuditDescription = "/Home/Index",
                IsExceptionThrown = false,
                TimeOfAction = new DateTime(),
                InternetProtocol = (string)jObject["IPv4"],
                DeveloperOrAnonymous = "anonymous",
                Country = (string)jObject["country_name"],
                CountryCode = (string)jObject["country_code"],
                Latitude = (string)jObject["latitude"],
                Longitude = (string)jObject["longitude"],
            };
            _context.Add(audit);
            await _context.SaveChangesAsync();
            
            ViewBag.audit = _context.Audits.ToList().Count;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(IFormCollection formFields)
        {
            var developerId = "";
            ShortBio shortBios;
            WorkingProfile workingProfile;
            
            try
            {
                developerId = _userManager.FindByNameAsync(formFields["developerUsername"]).Result.Id;
                
                shortBios = _context.ShortBios.Single(x => x.DeveloperId == developerId);
                
                workingProfile = _context.WorkingProfiles.Single(x => x.DeveloperId == developerId);
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
            var workingProfile = _context.WorkingProfiles.Single(x => x.DeveloperId == developerId);
            
            var uHuntAPI = "";
            var codeForcesAPI = "";
            
            using (WebClient webClient = new WebClient())
            {
                if (workingProfile.CodeforcesUsername != null && workingProfile.CodeforcesUsername.Trim() != "")
                {
                    codeForcesAPI = new WebClient().DownloadString("https://codeforces.com/api/user.info?handles="+workingProfile.CodeforcesUsername);
                }
                if (workingProfile.UhuntUsername != null && workingProfile.UhuntUsername.Trim() != "")
                {
                    uHuntAPI = new WebClient().DownloadString("https://uhunt.onlinejudge.org/api/uname2uid/"+workingProfile.UhuntUsername);
                }
            }
            return Ok(shortBios);
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