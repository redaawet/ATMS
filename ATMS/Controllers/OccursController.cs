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
    public class OccursController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public OccursController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Occurs
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.Occurs.Include(o => o.AccidentRecord);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: Occurs/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occur = await _context.Occurs
                .Include(o => o.AccidentRecord)
                .SingleOrDefaultAsync(m => m.AccidentTime == id);
            if (occur == null)
            {
                return NotFound();
            }

            return View(occur);
        }

        // GET: Occurs/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            return View();
        }

        // POST: Occurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentTime,AccidentRecordID")] Occur occur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", occur.AccidentRecordID);
            return View(occur);
        }

        // GET: Occurs/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occur = await _context.Occurs.SingleOrDefaultAsync(m => m.AccidentTime == id);
            if (occur == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", occur.AccidentRecordID);
            return View(occur);
        }

        // POST: Occurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("AccidentTime,AccidentRecordID")] Occur occur)
        {
            if (id != occur.AccidentTime)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccurExists(occur.AccidentTime))
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
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", occur.AccidentRecordID);
            return View(occur);
        }

        // GET: Occurs/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occur = await _context.Occurs
                .Include(o => o.AccidentRecord)
                .SingleOrDefaultAsync(m => m.AccidentTime == id);
            if (occur == null)
            {
                return NotFound();
            }

            return View(occur);
        }

        // POST: Occurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var occur = await _context.Occurs.SingleOrDefaultAsync(m => m.AccidentTime == id);
            _context.Occurs.Remove(occur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OccurExists(DateTime id)
        {
            return _context.Occurs.Any(e => e.AccidentTime == id);
        }
    }
}
