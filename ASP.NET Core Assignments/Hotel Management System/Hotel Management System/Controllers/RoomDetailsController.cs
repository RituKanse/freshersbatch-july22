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
    [Authorize(Roles = "Owner,Manager,Receptionist")]
    public class RoomDetailsController : Controller
    {
        private readonly HotelManagementSystemContext _context;

        public RoomDetailsController(HotelManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return      View();
        }

        // GET: RoomDetails
        public async Task<IActionResult> Index()
        {
            var hotelManagementSystemContext = _context.RoomDetails.Include(r => r.Reservation).Include(r => r.Room);
            return View(await hotelManagementSystemContext.ToListAsync());
        }

        // GET: RoomDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails
                .Include(r => r.Reservation)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            return View(roomDetails);
        }

        // GET: RoomDetails/Create
        public IActionResult Create()
        {
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "ReservationId", "ReservationId");
            ViewData["RoomId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: RoomDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,ReservationId,CheckIn,CheckOut,Period,ServiceId")] RoomDetails roomDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "ReservationId", "ReservationId", roomDetails.ReservationId);
            ViewData["RoomId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", roomDetails.RoomId);
            return View(roomDetails);
        }

        // GET: RoomDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails.FindAsync(id);
            if (roomDetails == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "ReservationId", "ReservationId", roomDetails.ReservationId);
            ViewData["RoomId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", roomDetails.RoomId);
            return View(roomDetails);
        }

        // POST: RoomDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,ReservationId,CheckIn,CheckOut,Period,ServiceId")] RoomDetails roomDetails)
        {
            if (id != roomDetails.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomDetailsExists(roomDetails.RoomId))
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
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "ReservationId", "ReservationId", roomDetails.ReservationId);
            ViewData["RoomId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", roomDetails.RoomId);
            return View(roomDetails);
        }

        // GET: RoomDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomDetails = await _context.RoomDetails
                .Include(r => r.Reservation)
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (roomDetails == null)
            {
                return NotFound();
            }

            return View(roomDetails);
        }

        // POST: RoomDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomDetails = await _context.RoomDetails.FindAsync(id);
            _context.RoomDetails.Remove(roomDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomDetailsExists(int id)
        {
            return _context.RoomDetails.Any(e => e.RoomId == id);
        }
    }
}
