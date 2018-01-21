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
    public class InjuresController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public InjuresController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Injures
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.Injures.Include(i => i.AccidentRecords).Include(i => i.Victims);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: Injures/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injures = await _context.Injures
                .Include(i => i.AccidentRecords)
                .Include(i => i.Victims)
                .SingleOrDefaultAsync(m => m.VictimID == id);
            if (injures == null)
            {
                return NotFound();
            }

            return View(injures);
        }

        // GET: Injures/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            ViewData["VictimID"] = new SelectList(_context.Victims, "VictimID", "VictimID");
            return View();
        }

        // POST: Injures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentRecordID,VictimID")] Injures injures)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injures);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", injures.AccidentRecordID);
            ViewData["VictimID"] = new SelectList(_context.Victims, "VictimID", "VictimID", injures.VictimID);
            return View(injures);
        }

        // GET: Injures/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injures = await _context.Injures.SingleOrDefaultAsync(m => m.VictimID == id);
            if (injures == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", injures.AccidentRecordID);
            ViewData["VictimID"] = new SelectList(_context.Victims, "VictimID", "VictimID", injures.VictimID);
            return View(injures);
        }

        // POST: Injures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccidentRecordID,VictimID")] Injures injures)
        {
            if (id != injures.VictimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injures);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjuresExists(injures.VictimID))
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
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", injures.AccidentRecordID);
            ViewData["VictimID"] = new SelectList(_context.Victims, "VictimID", "VictimID", injures.VictimID);
            return View(injures);
        }

        // GET: Injures/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injures = await _context.Injures
                .Include(i => i.AccidentRecords)
                .Include(i => i.Victims)
                .SingleOrDefaultAsync(m => m.VictimID == id);
            if (injures == null)
            {
                return NotFound();
            }

            return View(injures);
        }

        // POST: Injures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var injures = await _context.Injures.SingleOrDefaultAsync(m => m.VictimID == id);
            _context.Injures.Remove(injures);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InjuresExists(string id)
        {
            return _context.Injures.Any(e => e.VictimID == id);
        }
    }
}
