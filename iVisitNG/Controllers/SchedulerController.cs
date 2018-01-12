using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace iVisitNG.Controllers
{

    [Authorize]
    public class SchedulerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Staff> _userManager;

        public SchedulerController(ApplicationDbContext context, UserManager<Staff> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Scheduler
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var applicationDbContext = _context.BusySchedule
                .Where(u => u.StaffId == userId)
                .Include(b => b.Staff);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Scheduler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busySchedule = await _context.BusySchedule
                .Include(b => b.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (busySchedule == null)
            {
                return NotFound();
            }

            return View(busySchedule);
        }

        // GET: Scheduler/Create
        public IActionResult Create()
        {
            return View( new SchedulerFormModal() );
        }

        // POST: Scheduler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchedulerFormModal busySchedule)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                DateTime to = DateTime.ParseExact(busySchedule.ToDateTime, "yyyy-MM-dd hh:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
                DateTime from = DateTime.ParseExact(busySchedule.FromDateTime, "yyyy-MM-dd hh:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

                var scheduler = new BusySchedule
                {
                    Reason = busySchedule.Reason,
                    FromDateTime = from,
                    ToDateTime = to,
                    StaffId = userId,
                    CreatedDate = DateTime.Now
                };

                _context.BusySchedule.Add(scheduler);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["StaffId"] = new SelectList(_context.Users, "Id", "Id", busySchedule.StaffId);
            return View(busySchedule);
        }

        // GET: Scheduler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(HttpContext.User);
            var busySchedule = await _context.BusySchedule
                .Where(u => u.StaffId == userId)
                .SingleOrDefaultAsync(m => m.Id == id);
            
            if (busySchedule == null)
            {
                return NotFound();
            }

            var scheduler = new SchedulerFormModal(busySchedule);

            return View(scheduler);
        }

        // POST: Scheduler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reason,FromDateTime,ToDateTime")] BusySchedule busySchedule)
        {
            if (id != busySchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busySchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusyScheduleExists(busySchedule.Id))
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
            var bs = new SchedulerFormModal(busySchedule);
            return View(bs);
        }

        // GET: Scheduler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busySchedule = await _context.BusySchedule
                .Include(b => b.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (busySchedule == null)
            {
                return NotFound();
            }

            return View(busySchedule);
        }

        // POST: Scheduler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busySchedule = await _context.BusySchedule.SingleOrDefaultAsync(m => m.Id == id);
            _context.BusySchedule.Remove(busySchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusyScheduleExists(int id)
        {
            return _context.BusySchedule.Any(e => e.Id == id);
        }
    }
}
