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
    public class RoadGeometriesController : Controller
    {
        private readonly TrafficAccidentManagementContext _context;

        public RoadGeometriesController(TrafficAccidentManagementContext context)
        {
            _context = context;    
        }

        // GET: RoadGeometries
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoadGeometries.ToListAsync());
        }

        // GET: RoadGeometries/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roadGeometry = await _context.RoadGeometries
                .SingleOrDefaultAsync(m => m.RoadName == id);
            if (roadGeometry == null)
            {
                return NotFound();
            }

            return View(roadGeometry);
        }

        // GET: RoadGeometries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoadGeometries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoadName,Latitude,Longutide,AADT,ADT,SurfaceType,SpeedLimit,NoLine,TrafficMovement,JunctionType,JunctionControl,RoadClassifaction,RoadWidth,CarriageWidth,ShoulderWidth,HorizontalFeature,VerticalFeature")] RoadGeometry roadGeometry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roadGeometry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roadGeometry);
        }

        // GET: RoadGeometries/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roadGeometry = await _context.RoadGeometries.SingleOrDefaultAsync(m => m.RoadName == id);
            if (roadGeometry == null)
            {
                return NotFound();
            }
            return View(roadGeometry);
        }

        // POST: RoadGeometries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoadName,Latitude,Longutide,AADT,ADT,SurfaceType,SpeedLimit,NoLine,TrafficMovement,JunctionType,JunctionControl,RoadClassifaction,RoadWidth,CarriageWidth,ShoulderWidth,HorizontalFeature,VerticalFeature")] RoadGeometry roadGeometry)
        {
            if (id != roadGeometry.RoadName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roadGeometry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoadGeometryExists(roadGeometry.RoadName))
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
            return View(roadGeometry);
        }

        // GET: RoadGeometries/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roadGeometry = await _context.RoadGeometries
                .SingleOrDefaultAsync(m => m.RoadName == id);
            if (roadGeometry == null)
            {
                return NotFound();
            }

            return View(roadGeometry);
        }

        // POST: RoadGeometries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roadGeometry = await _context.RoadGeometries.SingleOrDefaultAsync(m => m.RoadName == id);
            _context.RoadGeometries.Remove(roadGeometry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoadGeometryExists(string id)
        {
            return _context.RoadGeometries.Any(e => e.RoadName == id);
        }
    }
}
