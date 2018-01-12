using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVisitNG.Data;
using iVisitNG.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iVisitNG.Controllers
{
    [Authorize]
    public class MyCalenderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Staff> _userManager;

        public MyCalenderController(ApplicationDbContext context, UserManager<Staff> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var staff = _context.StaffProfile.SingleOrDefault(m => m.StaffId == userId);

            var appointment = (from a in _context.Appointment
                join v in _context.Visitor on a.VisitorId equals v.Id
                where (a.StaffId == userId)
                select new
                {
                    a.AppointmentDateTimes,
                    v.FirstName,
                    v.LastName
                }).ToList();

            //var visitorname = appointment.FirstOrDefault().FirstName + " " + appointment.FirstOrDefault().LastName;
            var name = staff.FirstName + " " + staff.LastName;
            //var appointmentDate = appointment.FirstOrDefault().AppointmentDateTimes;

            HttpContext.Session.SetString("Name", name);
            //HttpContext.Session.SetString("Visitorname", visitorname);
            //HttpContext.Session.SetString("AppointmentDate", appointmentDate.ToString());

            return View();
        }

        [AllowAnonymous]
        [HttpGet("/api/calender/schedule")]
        public IActionResult GetBusySchedule()
        {
            var events = _context.BusySchedule.ToList();
            return Json(events);
        }

        [AllowAnonymous]
        [HttpGet("/api/calender/appointments")]
        public JsonResult GetAppointment()
        {
            var events = _context.Visitor.ToList();
            return Json(events);
        }
    }
}