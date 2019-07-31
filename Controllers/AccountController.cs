using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoResume.Models;

namespace NoResume.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        
        /*
         * HttpGet : When request comes to Account/Register
         * this page's View will be shown
         */
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        
        /*
         * HttpGet : When request comes to Account/Login
         * this page's View will be shown
         */
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        
        /*
         * HttpPost : When request comes to calculate some sort form data,
         * this will get generated
         */
        [HttpPost]
        public async Task<IActionResult> Register(InitDevelopers initDevelopers, String returnUrl)
        {
            if (ModelState.IsValid)
            {
                MailAddress mailAddress = new MailAddress(initDevelopers.DevEmail);
                initDevelopers.DevId = Guid.NewGuid().ToString().Replace("-", "");
                var userObject = new IdentityUser{ Id = initDevelopers.DevId, UserName = mailAddress.User, Email = initDevelopers.DevEmail};
                var userCreationResult = await _userManager.CreateAsync(userObject, initDevelopers.DevPassword);

                if (userCreationResult.Succeeded)
                {
                    await _signInManager.SignInAsync(userObject, isPersistent:false);
                    var shortBio = new ShortBio
                    {
                        DeveloperId = initDevelopers.DevId
                    };

                    var social = new SocialProfile
                    {
                        DeveloperId = initDevelopers.DevId
                    };

                    var workingProfile = new WorkingProfile
                    {
                        DeveloperId = initDevelopers.DevId
                    };

                    _context.Add(shortBio);
                    _context.Add(social);
                    _context.Add(workingProfile);
                    await _context.SaveChangesAsync();
                    
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Edit", "ShortBios", new { id = initDevelopers.DevId });
                }
                
                foreach (var error in userCreationResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(initDevelopers);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDevelopers model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(model.DevEmail);
                var user = new IdentityUser{ UserName = address.User, Email = model.DevEmail };

                var result = await 
                    _signInManager.PasswordSignInAsync(user.UserName, model.DevPassword, isPersistent: true, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    
                    return RedirectToAction("Edit", "ShortBios", new { id = _getCurrentlyLoggedInUser() });
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        private string _getCurrentlyLoggedInUser()
        {
            return _userManager.GetUserId(HttpContext.User);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}