using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2G1.Data;
using Garage2G1.Models;
using Garage2G1.Models.ViewModel;

namespace Garage2G1.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly ParkedVehicleContext db;

        public ParkedVehiclesController(ParkedVehicleContext context)
        {
            db = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index(string searchString, VehicleType? vehicleType)
        {
            /* 
            var pv = db.ParkedVehicle.Select(p => new ParkedVehicleViewModel 
            {
                Id = p.Id,
                VehicleType = p.VehicleType,
                RegNumber = p.RegNumber,
                Color = p.Color,
                Brand = p.Brand,
                Model = p.Model,
                NumberOfWheels = p.NumberOfWheels,
                ArrivalTime = p.ArrivalTime
            });

            if (!String.IsNullOrEmpty(searchString)) 
            {
                pv = pv.Where(p => p.RegNumber.Contains(searchString));
            } */
            var parkedVehicles = db.ParkedVehicle.Select(pv => pv);

            if (!string.IsNullOrEmpty(searchString)) 
            {
                parkedVehicles = parkedVehicles.Where(p => 
                                                p.RegNumber.ToLower().Contains(searchString.ToLower()));
            }
            if (vehicleType is not null)
            {
                parkedVehicles = parkedVehicles.Where(p => p.VehicleType == vehicleType);
            }

            // return View(nameof(Index), await db.ParkedVehicle.ToListAsync());
            return View(await parkedVehicles.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParkedVehicle parkedVehicle)
        {
            bool RegNumberExist = db.ParkedVehicle
                                    .Any(v => 
                                        v.RegNumber.ToLower().Equals(parkedVehicle.RegNumber.ToLower()));

            if (RegNumberExist)
            {
                ModelState.AddModelError(string.Empty, "Registration Number already exist.");
            } 
            else if (ModelState.IsValid)
            {
                parkedVehicle.ArrivalTime = DateTime.Now;
                db.Add(parkedVehicle);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            bool RegNumberExist = db.ParkedVehicle
                                    .Any(v => 
                                        v.Id != parkedVehicle.Id && 
                                        v.RegNumber.ToLower().Equals(parkedVehicle.RegNumber.ToLower()));

            if (RegNumberExist)
            {
                ModelState.AddModelError(string.Empty, "Registration Number already exist.");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    db.Update(parkedVehicle);
                    db.Entry(parkedVehicle).Property("ArrivalTime").IsModified = false;
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await db.ParkedVehicle
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await db.ParkedVehicle.FindAsync(id);
            db.ParkedVehicle.Remove(parkedVehicle);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return db.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}
