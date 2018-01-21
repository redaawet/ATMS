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
    public class DamagesController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public DamagesController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Damages
        public async Task<IActionResult> Index()
        {
            var trafficAccidentManagementContext = _context.Damages.Include(d => d.AccidentRecords).Include(d => d.Properieties);
            return View(await trafficAccidentManagementContext.ToListAsync());
        }

        // GET: Damages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damages
                .Include(d => d.AccidentRecords)
                .Include(d => d.Properieties)
                .SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (damage == null)
            {
                return NotFound();
            }

            return View(damage);
        }

        // GET: Damages/Create
        public IActionResult Create()
        {
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID");
            ViewData["ProperietyID"] = new SelectList(_context.Properieties, "ProperietyID", "ProperietyID");
            return View();
        }

        // POST: Damages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentRecordID,ProperietyID,ProperietyCost")] Damage damage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(damage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", damage.AccidentRecordID);
            ViewData["ProperietyID"] = new SelectList(_context.Properieties, "ProperietyID", "ProperietyID", damage.ProperietyID);
            return View(damage);
        }

        // GET: Damages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damages.SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (damage == null)
            {
                return NotFound();
            }
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", damage.AccidentRecordID);
            ViewData["ProperietyID"] = new SelectList(_context.Properieties, "ProperietyID", "ProperietyID", damage.ProperietyID);
            return View(damage);
        }

        // POST: Damages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccidentRecordID,ProperietyID,ProperietyCost")] Damage damage)
        {
            if (id != damage.ProperietyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamageExists(damage.ProperietyID))
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
            ViewData["AccidentRecordID"] = new SelectList(_context.AccidentRecords, "AccidentRecordID", "AccidentRecordID", damage.AccidentRecordID);
            ViewData["ProperietyID"] = new SelectList(_context.Properieties, "ProperietyID", "ProperietyID", damage.ProperietyID);
            return View(damage);
        }

        // GET: Damages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damage = await _context.Damages
                .Include(d => d.AccidentRecords)
                .Include(d => d.Properieties)
                .SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (damage == null)
            {
                return NotFound();
            }

            return View(damage);
        }

        // POST: Damages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var damage = await _context.Damages.SingleOrDefaultAsync(m => m.ProperietyID == id);
            _context.Damages.Remove(damage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DamageExists(string id)
        {
            return _context.Damages.Any(e => e.ProperietyID == id);
        }
    }
}
