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
    public class FactoryAndAccidentsController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public FactoryAndAccidentsController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: FactoryAndAccidents
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.Factors.Include(f => f.AccidentRecords).Include(f => f.Factories);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: FactoryAndAccidents/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryAndAccident = await _context.Factors
                .Include(f => f.AccidentRecords)
                .Include(f => f.Factories)
                .SingleOrDefaultAsync(m => m.AccidentRecordId == id);
            if (factoryAndAccident == null)
            {
                return NotFound();
            }

            return View(factoryAndAccident);
        }

        // GET: FactoryAndAccidents/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordId"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactorID", "FactorID");
            return View();
        }

        // POST: FactoryAndAccidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactoryId,AccidentRecordId")] FactoryAndAccident factoryAndAccident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factoryAndAccident);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordId"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", factoryAndAccident.AccidentRecordId);
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactorID", "FactorID", factoryAndAccident.FactoryId);
            return View(factoryAndAccident);
        }

        // GET: FactoryAndAccidents/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryAndAccident = await _context.Factors.SingleOrDefaultAsync(m => m.AccidentRecordId == id);
            if (factoryAndAccident == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordId"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", factoryAndAccident.AccidentRecordId);
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactorID", "FactorID", factoryAndAccident.FactoryId);
            return View(factoryAndAccident);
        }

        // POST: FactoryAndAccidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FactoryId,AccidentRecordId")] FactoryAndAccident factoryAndAccident)
        {
            if (id != factoryAndAccident.AccidentRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factoryAndAccident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactoryAndAccidentExists(factoryAndAccident.AccidentRecordId))
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
            ViewData["AccidentRecordId"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", factoryAndAccident.AccidentRecordId);
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactorID", "FactorID", factoryAndAccident.FactoryId);
            return View(factoryAndAccident);
        }

        // GET: FactoryAndAccidents/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factoryAndAccident = await _context.Factors
                .Include(f => f.AccidentRecords)
                .Include(f => f.Factories)
                .SingleOrDefaultAsync(m => m.AccidentRecordId == id);
            if (factoryAndAccident == null)
            {
                return NotFound();
            }

            return View(factoryAndAccident);
        }

        // POST: FactoryAndAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var factoryAndAccident = await _context.Factors.SingleOrDefaultAsync(m => m.AccidentRecordId == id);
            _context.Factors.Remove(factoryAndAccident);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FactoryAndAccidentExists(string id)
        {
            return _context.Factors.Any(e => e.AccidentRecordId == id);
        }
    }
}
