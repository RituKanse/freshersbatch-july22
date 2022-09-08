using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS_Data_Access.HMSModels;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_Management_System.Controllers
{
    [Authorize(Roles = "Owner,Receptionist")]
    public class GuestDetailsController : Controller
    {
        private readonly HotelManagementSystemContext _context;
        
        public GuestDetailsController(HotelManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return View();
        }
        // GET: GuestDetails
        public async Task<IActionResult> Index()
        {
            var hotelManagementSystemContext = _context.GuestDetails.Include(g => g.Room);
            return View(await hotelManagementSystemContext.ToListAsync());
        }

        // GET: GuestDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestDetails = await _context.GuestDetails
                .Include(g => g.Room)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guestDetails == null)
            {
                return NotFound();
            }

            return View(guestDetails);
        }
        
        // GET: GuestDetails/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.RoomDetails, "RoomId", "RoomId");
            return View();
        }

        // POST: GuestDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestId,GuestName,PhoneNumber,Company,Email,Gender,GuestAddress,RoomId")] GuestDetails guestDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.RoomDetails, "RoomId", "RoomId", guestDetails.RoomId);
            return View(guestDetails);
        }

        // GET: GuestDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestDetails = await _context.GuestDetails.FindAsync(id);
            if (guestDetails == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.RoomDetails, "RoomId", "RoomId", guestDetails.RoomId);
            return View(guestDetails);
        }

        // POST: GuestDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestId,GuestName,PhoneNumber,Company,Email,Gender,GuestAddress,RoomId")] GuestDetails guestDetails)
        {
            if (id != guestDetails.GuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestDetailsExists(guestDetails.GuestId))
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
            ViewData["RoomId"] = new SelectList(_context.RoomDetails, "RoomId", "RoomId", guestDetails.RoomId);
            return View(guestDetails);
        }

        // GET: GuestDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestDetails = await _context.GuestDetails
                .Include(g => g.Room)
                .FirstOrDefaultAsync(m => m.GuestId == id);
            if (guestDetails == null)
            {
                return NotFound();
            }

            return View(guestDetails);
        }

        // POST: GuestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestDetails = await _context.GuestDetails.FindAsync(id);
            _context.GuestDetails.Remove(guestDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestDetailsExists(int id)
        {
            return _context.GuestDetails.Any(e => e.GuestId == id);
        }
    }
}
