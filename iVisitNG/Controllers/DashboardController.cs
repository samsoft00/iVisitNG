using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iVisitNG.Data;
using iVisitNG.Models;
using iVisitNG.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iVisitNG.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<Staff> _userManager;
        private readonly SignInManager<Staff> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IFlashMessage _flashMessage;
        private readonly ApplicationDbContext _context;
        private string userId;

        public DashboardController(
            UserManager<Staff> userManager,
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            //IFlashMessage flashMessage,
            SignInManager<Staff> signInManager)
        {
            _userManager = userManager;
            _context = context;
            this._roleManager = roleManager;
            //_flashMessage = flashMessage;
            _signInManager = signInManager;
            userId = "";
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ViewData["userId"] = userId;

            var visitorLists = this._context.Appointment
                .Where(s => s.StaffId == userId)
                .Include(v => v.Visitor).Select(m => m.Visitor);

            var categories = from x in _context.Category select x;
            var countries = from c in _context.Country select c;
            var daysOfWeeks = from d in _context.DaysOfWeek select d;
            var purposeOfVisit = from p in _context.PurposeOfVisit select p;
            var notification = from n in _context.Notification select n;

            //get stats
            var stats = new StatisticViewModel()
            {
                staffs = _context.Staff.Count(),
                visitors = _context.Staff.Count(),
                tenants = _context.ZonalOffice.Count(),
                appointment = _context.Appointment.Count()
            };

            //var visitorLists = from appt in _context.Appointment.Include(m => m.Visitor)
            //    where appt.StaffId == this.userId
            //    select appt.Visitor;

            var viewModel = new AppointmentSchedulerViewModel()
            {
                Categories = categories,
                Countries = countries,
                Visitors = visitorLists,
                PurposeOfVisit = purposeOfVisit,
                stats = stats,
                Notifications = notification
            };

            return View(viewModel);
        }
    }
}