using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS_Data_Access.HMSModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hotel_Management_System.Controllers
{
    [Authorize(Roles = "Owner")]
    public class RatesController : Controller
    {
        private readonly HotelManagementSystemContext _context;

        public RatesController(HotelManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return View();
        }
        // GET: Rates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rates.ToListAsync());
        }

        // GET: Rates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rates = await _context.Rates
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (rates == null)
            {
                return NotFound();
            }

            return View(rates);
        }

        // GET: Rates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RateId,FirstNightPrice,ExtensionPrice")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rates);
        }

        // GET: Rates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rates = await _context.Rates.FindAsync(id);
            if (rates == null)
            {
                return NotFound();
            }
            return View(rates);
        }

        // POST: Rates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RateId,FirstNightPrice,ExtensionPrice")] Rates rates)
        {
            if (id != rates.RateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatesExists(rates.RateId))
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
            return View(rates);
        }

        // GET: Rates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rates = await _context.Rates
                .FirstOrDefaultAsync(m => m.RateId == id);
            if (rates == null)
            {
                return NotFound();
            }

            return View(rates);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rates = await _context.Rates.FindAsync(id);
            _context.Rates.Remove(rates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatesExists(int id)
        {
            return _context.Rates.Any(e => e.RateId == id);
        }
    }
}
