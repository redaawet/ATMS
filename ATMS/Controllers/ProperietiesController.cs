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
    public class ProperietiesController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public ProperietiesController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Properieties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Properieties.ToListAsync());
        }

        // GET: Properieties/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properiety = await _context.Properieties
                .SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (properiety == null)
            {
                return NotFound();
            }

            return View(properiety);
        }

        // GET: Properieties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properieties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProperietyID,ProperietyType")] Properiety properiety)
        {
            if (ModelState.IsValid)
            {
                _context.Add(properiety);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(properiety);
        }

        // GET: Properieties/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properiety = await _context.Properieties.SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (properiety == null)
            {
                return NotFound();
            }
            return View(properiety);
        }

        // POST: Properieties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProperietyID,ProperietyType")] Properiety properiety)
        {
            if (id != properiety.ProperietyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(properiety);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProperietyExists(properiety.ProperietyID))
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
            return View(properiety);
        }

        // GET: Properieties/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properiety = await _context.Properieties
                .SingleOrDefaultAsync(m => m.ProperietyID == id);
            if (properiety == null)
            {
                return NotFound();
            }

            return View(properiety);
        }

        // POST: Properieties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var properiety = await _context.Properieties.SingleOrDefaultAsync(m => m.ProperietyID == id);
            _context.Properieties.Remove(properiety);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProperietyExists(string id)
        {
            return _context.Properieties.Any(e => e.ProperietyID == id);
        }
    }
}
