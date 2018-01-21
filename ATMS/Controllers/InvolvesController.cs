using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATMSData.Models;

namespace ATMS.Controllers
{
    public class InvolvesController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public InvolvesController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Involves
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.Involves.Include(i => i.AccidentRecords).Include(i => i.Drivers);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: Involves/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var involve = await _context.Involves
                .Include(i => i.AccidentRecords)
                .Include(i => i.Drivers)
                .SingleOrDefaultAsync(m => m.DriverID == id);
            if (involve == null)
            {
                return NotFound();
            }

            return View(involve);
        }

        // GET: Involves/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "DriverID");
            return View();
        }

        // POST: Involves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentRecordID,DriverID")] Involve involve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(involve);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", involve.AccidentRecordID);
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "DriverID", involve.DriverID);
            return View(involve);
        }

        // GET: Involves/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var involve = await _context.Involves.SingleOrDefaultAsync(m => m.DriverID == id);
            if (involve == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", involve.AccidentRecordID);
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "DriverID", involve.DriverID);
            return View(involve);
        }

        // POST: Involves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccidentRecordID,DriverID")] Involve involve)
        {
            if (id != involve.DriverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(involve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvolveExists(involve.DriverID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", involve.AccidentRecordID);
            ViewData["DriverID"] = new SelectList(_context.Drivers, "DriverID", "DriverID", involve.DriverID);
            return View(involve);
        }

        // GET: Involves/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var involve = await _context.Involves
                .Include(i => i.AccidentRecords)
                .Include(i => i.Drivers)
                .SingleOrDefaultAsync(m => m.DriverID == id);
            if (involve == null)
            {
                return NotFound();
            }

            return View(involve);
        }

        // POST: Involves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var involve = await _context.Involves.SingleOrDefaultAsync(m => m.DriverID == id);
            _context.Involves.Remove(involve);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InvolveExists(string id)
        {
            return _context.Involves.Any(e => e.DriverID == id);
        }
    }
}
