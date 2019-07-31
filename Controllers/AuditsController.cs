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
    public class AuditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Audits
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audits.ToListAsync());
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLogging = await _context.Audits
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (auditLogging == null)
            {
                return NotFound();
            }

            return View(auditLogging);
        }

        // GET: Audits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Audits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditId,AuditDescription,IsExceptionThrown,DeveloperOrAnonymous,TimeOfAction,InternetProtocol,Country,CountryCode,Latitude,Longitude")] AuditLogging auditLogging)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditLogging);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditLogging);
        }

        // GET: Audits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLogging = await _context.Audits.FindAsync(id);
            if (auditLogging == null)
            {
                return NotFound();
            }
            return View(auditLogging);
        }

        // POST: Audits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AuditId,AuditDescription,IsExceptionThrown,DeveloperOrAnonymous,TimeOfAction,InternetProtocol,Country,CountryCode,Latitude,Longitude")] AuditLogging auditLogging)
        {
            if (id != auditLogging.AuditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditLogging);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditLoggingExists(auditLogging.AuditId))
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
            return View(auditLogging);
        }

        // GET: Audits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditLogging = await _context.Audits
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (auditLogging == null)
            {
                return NotFound();
            }

            return View(auditLogging);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var auditLogging = await _context.Audits.FindAsync(id);
            _context.Audits.Remove(auditLogging);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditLoggingExists(string id)
        {
            return _context.Audits.Any(e => e.AuditId == id);
        }
    }
}
