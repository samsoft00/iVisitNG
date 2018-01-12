using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iVisitNG.Data;
using Microsoft.AspNetCore.Mvc;

namespace iVisitNG.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            var appointment = (from a in _context.Appointment
                join v in _context.Visitor on a.VisitorId equals v.Id
                where (a.Id == id)
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

            return View();
        }
    }
}