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
    public class CauseOnsController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public CauseOnsController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: CauseOns
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.CausesOn.Include(c => c.AccidentRecords).Include(c => c.Vehicles);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: CauseOns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causeOn = await _context.CausesOn
                .Include(c => c.AccidentRecords)
                .Include(c => c.Vehicles)
                .SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (causeOn == null)
            {
                return NotFound();
            }

            return View(causeOn);
        }

        // GET: CauseOns/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID");
            return View();
        }

        // POST: CauseOns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentRecordID,VehicleID,VehicleCost")] CauseOn causeOn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(causeOn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", causeOn.AccidentRecordID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", causeOn.VehicleID);
            return View(causeOn);
        }

        // GET: CauseOns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causeOn = await _context.CausesOn.SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (causeOn == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", causeOn.AccidentRecordID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", causeOn.VehicleID);
            return View(causeOn);
        }

        // POST: CauseOns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccidentRecordID,VehicleID,VehicleCost")] CauseOn causeOn)
        {
            if (id != causeOn.AccidentRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(causeOn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauseOnExists(causeOn.AccidentRecordID))
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
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", causeOn.AccidentRecordID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", causeOn.VehicleID);
            return View(causeOn);
        }

        // GET: CauseOns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var causeOn = await _context.CausesOn
                .Include(c => c.AccidentRecords)
                .Include(c => c.Vehicles)
                .SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (causeOn == null)
            {
                return NotFound();
            }

            return View(causeOn);
        }

        // POST: CauseOns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var causeOn = await _context.CausesOn.SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            _context.CausesOn.Remove(causeOn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CauseOnExists(string id)
        {
            return _context.CausesOn.Any(e => e.AccidentRecordID == id);
        }
    }
}
