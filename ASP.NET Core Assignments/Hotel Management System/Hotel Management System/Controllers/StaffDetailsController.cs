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
    [Authorize(Roles = "Owner,Manager")]
    public class StaffDetailsController : Controller
    {
        private readonly HotelManagementSystemContext _context;

        public StaffDetailsController(HotelManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return View();
        }
        // GET: StaffDetails
        public async Task<IActionResult> Index()
        {
            var hotelManagementSystemContext = _context.StaffDetails.Include(s => s.Department);
            return View(await hotelManagementSystemContext.ToListAsync());
        }

        // GET: StaffDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffDetails = await _context.StaffDetails
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffDetails == null)
            {
                return NotFound();
            }

            return View(staffDetails);
        }

        // GET: StaffDetails/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId");
            return View();
        }

        // POST: StaffDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,StaffName,StaffAddress,Occupation,Email,Age,Salary,Nic,DepartmentId")] StaffDetails staffDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", staffDetails.DepartmentId);
            return View(staffDetails);
        }

        // GET: StaffDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffDetails = await _context.StaffDetails.FindAsync(id);
            if (staffDetails == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", staffDetails.DepartmentId);
            return View(staffDetails);
        }

        // POST: StaffDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,StaffAddress,Occupation,Email,Age,Salary,Nic,DepartmentId")] StaffDetails staffDetails)
        {
            if (id != staffDetails.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffDetailsExists(staffDetails.StaffId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentId", staffDetails.DepartmentId);
            return View(staffDetails);
        }

        // GET: StaffDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffDetails = await _context.StaffDetails
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffDetails == null)
            {
                return NotFound();
            }

            return View(staffDetails);
        }

        // POST: StaffDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffDetails = await _context.StaffDetails.FindAsync(id);
            _context.StaffDetails.Remove(staffDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffDetailsExists(int id)
        {
            return _context.StaffDetails.Any(e => e.StaffId == id);
        }
    }
}
