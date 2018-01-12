using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iVisitNG.Data;
using iVisitNG.Models;
using iVisitNG.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Vereyon.Web;

namespace iVisitNG.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Staff> _userManager;
        private readonly IFlashMessage _flashMessage;

        public ProfileController(ApplicationDbContext context, UserManager<Staff> userManager,
            IFlashMessage flashMessage)
        {
            _context = context;
            _userManager = userManager;
            _flashMessage = flashMessage;
        }

        // GET: Profiles
        /*
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffProfile.Include(p => p.Staff).Include(p => p.ZonalOffice);
            return View(await applicationDbContext.ToListAsync());
        }
        */

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var profile = await _context.StaffProfile
                .Include(p => p.Staff)
                .Include(p => p.ZonalOffice)
                .SingleOrDefaultAsync(m => m.StaffId == userId);

            return View(profile);
        }

        // GET: Profiles/Create
        public async Task<IActionResult> Update()
        {
            ViewData["ZonalOfficeId"] = new SelectList(_context.ZonalOffice, "Id", "Name");

            //check if profile already updated
            var userId = _userManager.GetUserId(HttpContext.User);
            var s = _context.Staff.SingleOrDefault(m => m.Id == userId);
            if (s.IsProfileSetUp)
            {
                var profile = await _context.StaffProfile.SingleOrDefaultAsync(m => m.StaffId == userId);
                var profileView = new ProfileFormView()
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    ZonalOfficeId = profile.ZonalOfficeId
                };
                return View("Update", profileView);
            }

            return View("Update");
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("FirstName,LastName,ZonalOfficeId")] ProfileFormView profile)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var s = _context.Staff.SingleOrDefault(m => m.Id == userId);
                if (!s.IsProfileSetUp)
                {
                    var p = new Profile()
                    {
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        DateCreated = DateTime.Now,
                        ZonalOfficeId = profile.ZonalOfficeId,
                        StaffId = userId,
                        ImagePath = "-",

                    };

                    s.IsProfileSetUp = true;
                    _context.Staff.Update(s);
                    _context.Add(p);
                }
                else
                {
                    //select staffprofile and update it
                    var updateProfile = await _context.StaffProfile.SingleOrDefaultAsync(m => m.StaffId == s.Id);
                    updateProfile.FirstName = profile.FirstName;
                    updateProfile.LastName = profile.LastName;
                    updateProfile.ZonalOfficeId = profile.ZonalOfficeId;

                    _context.StaffProfile.Update(updateProfile);
                }
                
                await _context.SaveChangesAsync();
                _flashMessage.Confirmation("Profile Update Successfully!");

                return RedirectToRoute("Dashboard");
            }

            ViewData["ZonalOfficeId"] = new SelectList(_context.ZonalOffice, "Id", "Name", profile.ZonalOfficeId);
            return View("Update", profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.StaffProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", profile.StaffId);
            ViewData["ZonalOfficeId"] = new SelectList(_context.ZonalOffice, "Id", "Name", profile.ZonalOfficeId);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffId,ZonalOfficeId,FirstName,LastName,DateCreated,ImagePath")] Profile profile)
        {
            if (id != profile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToRoute("Dashboard");
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Id", profile.StaffId);
            ViewData["ZonalOfficeId"] = new SelectList(_context.ZonalOffice, "Id", "Name", profile.ZonalOfficeId);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.StaffProfile
                .Include(p => p.Staff)
                .Include(p => p.ZonalOffice)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.StaffProfile.SingleOrDefaultAsync(m => m.Id == id);
            _context.StaffProfile.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToRoute("Dashboard");
        }

        private bool ProfileExists(int id)
        {
            return _context.StaffProfile.Any(e => e.Id == id);
        }
    }
}
