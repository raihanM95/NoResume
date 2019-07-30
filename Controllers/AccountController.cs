using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
        public IActionResult Register()
        {
            return View();
        }
        
        /*
         * HttpGet : When request comes to Account/Login
         * this page's View will be shown
         */
        public IActionResult Login()
        {
            return View();
        }
        
        /*
         * HttpPost : When request comes to calculate some sort form data,
         * this will get generated
         */
        [HttpPost]
        public async Task<IActionResult> Register(InitDevelopers initDevelopers)
        {
            if (ModelState.IsValid)
            {
                MailAddress mailAddress = new MailAddress(initDevelopers.DevEmail);
                var guidedUserId = Guid.NewGuid().ToString().Replace("-", "");
                var userObject = new IdentityUser{ Id = guidedUserId, UserName = mailAddress.User, Email = initDevelopers.DevEmail};
                var userCreationResult = await _userManager.CreateAsync(userObject, initDevelopers.DevPassword);

                if (userCreationResult.Succeeded)
                {
                    await _signInManager.SignInAsync(userObject, isPersistent:false);
                    return RedirectToAction("Privacy", "Home");
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
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
            
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}