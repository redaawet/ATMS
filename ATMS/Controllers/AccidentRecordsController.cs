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
    public class AccidentRecordsController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public AccidentRecordsController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: AccidentRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccidentRecords.ToListAsync());
        }

        // GET: AccidentRecords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accidentRecord = await _context.AccidentRecords
                .SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (accidentRecord == null)
            {
                return NotFound();
            }

            return View(accidentRecord);
        }

        // GET: AccidentRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccidentRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccidentRecordID,City,SubCity,Descriptions")] AccidentRecord accidentRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accidentRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accidentRecord);
        }

        // GET: AccidentRecords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accidentRecord = await _context.AccidentRecords.SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (accidentRecord == null)
            {
                return NotFound();
            }
            return View(accidentRecord);
        }

        // POST: AccidentRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccidentRecordID,City,SubCity,Descriptions")] AccidentRecord accidentRecord)
        {
            if (id != accidentRecord.AccidentRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accidentRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccidentRecordExists(accidentRecord.AccidentRecordID))
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
            return View(accidentRecord);
        }

        // GET: AccidentRecords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accidentRecord = await _context.AccidentRecords
                .SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            if (accidentRecord == null)
            {
                return NotFound();
            }

            return View(accidentRecord);
        }

        // POST: AccidentRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accidentRecord = await _context.AccidentRecords.SingleOrDefaultAsync(m => m.AccidentRecordID == id);
            _context.AccidentRecords.Remove(accidentRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccidentRecordExists(string id)
        {
            return _context.AccidentRecords.Any(e => e.AccidentRecordID == id);
        }
    }
}
