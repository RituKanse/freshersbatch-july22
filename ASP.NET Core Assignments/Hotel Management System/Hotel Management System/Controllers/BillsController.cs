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
    [Authorize(Roles="Owner,Receptionist")]
    public class BillsController : Controller
    {
        
        private readonly HotelManagementSystemContext _context;

        public BillsController(HotelManagementSystemContext context)
        {
            _context = context;
        }
        public IActionResult Home()
        {
            return View();
        }
        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var hotelManagementSystemContext = _context.Bill.Include(b => b.Guest).Include(b => b.Service);
            return View(await hotelManagementSystemContext.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Guest)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["GuestId"] = new SelectList(_context.GuestDetails, "GuestId", "GuestId");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,GuestId,Taxes,IssueDate,ServiceId,Unit,CreditCardDetails,Price")] Bill bill, [Bind("Price")]Bill p)
        {
            if (ModelState.IsValid)
            {

                var nights = _context.Reservation.Where(b => b.GuestId==bill.GuestId).Select(s=>s.NumberOfNights).Single(); 
                var nightprice1 = _context.Rates.Select(s =>s.FirstNightPrice).FirstOrDefault();
                var nightprice2 = _context.Rates.Select(s => s.ExtensionPrice).FirstOrDefault();
                var serviceprice = _context.Services.Where(s=>s.ServiceId==bill.ServiceId).Select(s=>s.ServicePrice).Single();
                var price = ((1*nightprice1)+((nights)*nightprice2)+(serviceprice*bill.Unit)) ;

                _context.Add(new Bill
                {
                    BillId=bill.BillId,
                    GuestId=bill.GuestId,
                    Taxes=bill.Taxes,
                    IssueDate=bill.IssueDate,
                    ServiceId=bill.ServiceId,
                    Unit=bill.Unit,
                    CreditCardDetails=bill.CreditCardDetails,
                    Price=(decimal)price
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.GuestDetails, "GuestId", "GuestId", bill.GuestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", bill.ServiceId);
            
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.GuestDetails, "GuestId", "GuestId", bill.GuestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", bill.ServiceId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,GuestId,Taxes,IssueDate,ServiceId,Unit,CreditCardDetails,Price")] Bill bill)
        {
            if (id != bill.BillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.BillId))
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
            ViewData["GuestId"] = new SelectList(_context.GuestDetails, "GuestId", "GuestId", bill.GuestId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId", bill.ServiceId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.Guest)
                .Include(b => b.Service)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.BillId == id);
        }
    }
}
