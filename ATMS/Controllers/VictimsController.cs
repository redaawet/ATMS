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
    public class VictimsController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public VictimsController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: Victims
        public async Task<IActionResult> Index()
        {
            return View(await _context.Victims.ToListAsync());
        }

        // GET: Victims/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims
                .SingleOrDefaultAsync(m => m.VictimID == id);
            if (victim == null)
            {
                return NotFound();
            }

            return View(victim);
        }

        // GET: Victims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Victims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VictimID,FirstName,SecondName,LastName,sex,BirthDay,Age,Job")] Victim victim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(victim);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(victim);
        }

        // GET: Victims/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims.SingleOrDefaultAsync(m => m.VictimID == id);
            if (victim == null)
            {
                return NotFound();
            }
            return View(victim);
        }

        // POST: Victims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VictimID,FirstName,SecondName,LastName,sex,BirthDay,Age,Job")] Victim victim)
        {
            if (id != victim.VictimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(victim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VictimExists(victim.VictimID))
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
            return View(victim);
        }

        // GET: Victims/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var victim = await _context.Victims
                .SingleOrDefaultAsync(m => m.VictimID == id);
            if (victim == null)
            {
                return NotFound();
            }

            return View(victim);
        }

        // POST: Victims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var victim = await _context.Victims.SingleOrDefaultAsync(m => m.VictimID == id);
            _context.Victims.Remove(victim);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VictimExists(string id)
        {
            return _context.Victims.Any(e => e.VictimID == id);
        }
    }
}
