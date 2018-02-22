using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using iVisitNG.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iVisitNG.Data;
using iVisitNG.Models;
using iVisitNG.Models.ViewModels;

namespace iVisitNG.Controllers
{
    public class VisitorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visitor
        public async Task<IActionResult> Index()
        {
            var visitors = await _context.Visitor.ToListAsync();
            return View(visitors);
        }

        // GET: Visitor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor.SingleOrDefaultAsync(m => m.Id == id);

            if (visitor == null)
            {
                return NotFound();
            }

            return View(new VisitorRegistrationViewModel(visitor));
        }

        // GET: Visitor/Create
        public IActionResult Create()
        {
            var visitorFormViewModel = new VisitorRegistrationViewModel
            {
                Countries = _context.Country.ToList(),
                Categories = _context.Category.ToList(),
            };
            
            return View(visitorFormViewModel);
        }

        // POST: Visitor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitorRegistrationViewModel visitorReg)
        {
            if (ModelState.IsValid)
            {

                var visitor = new Visitor
                {
                    FirstName = visitorReg.FirstName,
                    LastName = visitorReg.LastName,
                    PhoneNumber = visitorReg.PhoneNumber,
                    Email = visitorReg.Email,
                    Company = visitorReg.Company,
                    RefNumber = Common.GenerateCode(),
                    OfficeAddress = visitorReg.OfficeAddress,
                    CategoryId = visitorReg.Category,
                    CountryId = visitorReg.Country,
                    //ImageUrl = visitorReg.GetImageUrl(),
                    CreatedDate = DateTime.Now
                };

                _context.Visitor.Add(visitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //RE
            var visitorFormViewModel = new VisitorRegistrationViewModel
            {
                Countries = _context.Country.ToList(),
                Categories = _context.Category.ToList(),
            };

            return View(visitorFormViewModel);
        }

        // GET: Visitor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor.SingleOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }
            return View(new VisitorRegistrationViewModel(visitor));
        }

        // POST: Visitor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,Company")] VisitorRegistrationViewModel visitorRegistrationViewModel)
        {
            if (id != visitorRegistrationViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitorRegistrationViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorRegistrationViewModelExists(visitorRegistrationViewModel.Id))
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
            return View(visitorRegistrationViewModel);
        }

        // GET: Visitor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitor.SingleOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(new VisitorRegistrationViewModel(visitor));
        }

        [HttpGet]
        public async Task<IActionResult> BlackListed()
        {
            var blackListedVisitor = await _context.Visitor.Where(m => m.IsBlackListed == true).ToListAsync();
            return View("blackListed", blackListedVisitor);
        }

        // POST: Visitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitorRegistrationViewModel = await _context.Visitor.SingleOrDefaultAsync(m => m.Id == id);
            _context.Visitor.Remove(visitorRegistrationViewModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool VisitorRegistrationViewModelExists(int id)
        {
            return _context.Visitor.Any(e => e.Id == id);
        }

        //api/visitor
        [HttpGet("/api/visitors")]
        public IActionResult GetAllVisitors()
        {
            var visitor = _context.Visitor
                .Include(c => c.Category)
                .Include(ctr => ctr.Country)
                .ToList();

            return Ok(visitor);
        }

        //api/visitor
        [HttpGet("/api/visitors/getVisitorByRef")]
        public IActionResult GetVisitorByRef()
        {
            string page = HttpContext.Request.Query["ref"].ToString();
            var visitor = _context.Visitor.Where(s => s.FirstName.Contains(page));

            return Json(visitor.ToList());
        }

        [HttpPost("/api/appointment/assign")]
        public IActionResult FixStaffAppointment([FromForm] SaveAppointmentResource appointmentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //check if visitor information exist in the database .Where(m => m.RefNumber == appointmentResource.VisitorRef) )
            var mVisitor = _context.Visitor.SingleOrDefault(m => m.RefNumber == appointmentResource.VisitorRef );
            var purpose = _context.PurposeOfVisit.SingleOrDefault(m => m.Id == appointmentResource.PurposeOfVisit);
            
            if (mVisitor == null)
            {
                return BadRequest("Invalid Visitor's Information");
            }

            DateTime to = DateTime.ParseExact(appointmentResource.EndDate, "yyyy-MM-dd hh:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));
            DateTime from = DateTime.ParseExact(appointmentResource.StartDate, "yyyy-MM-dd hh:mm:ss", CultureInfo.CreateSpecificCulture("en-US"));

            var appDateTime = new AppointmentDateTime();
            appDateTime.DateFrom = to;
            appDateTime.DateTo = from;

            var app = new Appointment()
            {
                StaffId = appointmentResource.StaffId,
                PurposeOfVisitId = purpose.Id,
                ApprovedStatus = true,
                VisitorId = mVisitor.Id,
                InstructionToSecurity = appointmentResource.Instruction,
                FloorNumber = appointmentResource.FloorNumber,
                IsGroupVisit = appointmentResource.IsGroupVisit == "Yes" ? true : false,
                CreatedAt = DateTime.Now

            };

            //app.AppointmentDateTimes.Add(appDateTime);

            _context.Appointment.Add(app);
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpGet("/api/appointment")]
        public IActionResult GetAllAppointment()
        {
            var appointment = (from a in _context.Appointment
                join v in _context.Visitor on a.VisitorId equals v.Id
                //where (a.StaffID == 6)
                select new
                {
                    a.Id,
                    v.FirstName,
                    v.LastName,
                    v.RefNumber,
                    v.PhoneNumber,
                    v.Company,
                    a.Purpose.purpose,
                    a.ApprovedStatus,
                    a.IsGroupVisit,
                    //  a.AppointmentDateTimes.SelectMany(x => new {x.DateFrom, x.DateTo})
                }).ToList();

            return Json(appointment);
        }

    }
}
