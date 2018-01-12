using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iVisitNG.Data;
using iVisitNG.Models;

namespace iVisitNG.Controllers
{
    public class ZonalOfficesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZonalOfficesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZonalOffices
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZonalOffice.ToListAsync());
        }

        // GET: ZonalOffices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonalOffice = await _context.ZonalOffice
                .SingleOrDefaultAsync(m => m.Id == id);
            if (zonalOffice == null)
            {
                return NotFound();
            }

            return View(zonalOffice);
        }

        // GET: ZonalOffices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZonalOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ZonalOffice zonalOffice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonalOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonalOffice);
        }

        // GET: ZonalOffices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonalOffice = await _context.ZonalOffice.SingleOrDefaultAsync(m => m.Id == id);
            if (zonalOffice == null)
            {
                return NotFound();
            }
            return View(zonalOffice);
        }

        // POST: ZonalOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ZonalOffice zonalOffice)
        {
            if (id != zonalOffice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonalOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonalOfficeExists(zonalOffice.Id))
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
            return View(zonalOffice);
        }

        // GET: ZonalOffices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonalOffice = await _context.ZonalOffice
                .SingleOrDefaultAsync(m => m.Id == id);
            if (zonalOffice == null)
            {
                return NotFound();
            }

            return View(zonalOffice);
        }

        // POST: ZonalOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zonalOffice = await _context.ZonalOffice.SingleOrDefaultAsync(m => m.Id == id);
            _context.ZonalOffice.Remove(zonalOffice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonalOfficeExists(int id)
        {
            return _context.ZonalOffice.Any(e => e.Id == id);
        }
    }
}
