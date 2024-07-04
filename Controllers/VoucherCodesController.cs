using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPartsHub.Models;

namespace AutoPartsHub.Controllers
{
    [CustomAuthentication]
    public class VoucherCodesController : Controller
    {
        private readonly AutoPartsHubContext _context;

        public VoucherCodesController(AutoPartsHubContext context)
        {
            _context = context;
        }

        // GET: VoucherCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblVoucherCodes.ToListAsync());
        }

        // GET: VoucherCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVoucherCode = await _context.TblVoucherCodes
                .FirstOrDefaultAsync(m => m.VoucherId == id);
            if (tblVoucherCode == null)
            {
                return NotFound();
            }

            return View(tblVoucherCode);
        }

        // GET: VoucherCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoucherCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoucherId,VoucherText,VoucherDiscount,Ispercentage,IsUsed,IsExpired,VoucherExpireDate,CreatedAt,CreatedBy,UpdatedAt,UpadetedBy,Mdelete")] TblVoucherCode tblVoucherCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblVoucherCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblVoucherCode);
        }

        // GET: VoucherCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVoucherCode = await _context.TblVoucherCodes.FindAsync(id);
            if (tblVoucherCode == null)
            {
                return NotFound();
            }
            return View(tblVoucherCode);
        }

        // POST: VoucherCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoucherId,VoucherText,VoucherDiscount,Ispercentage,IsUsed,IsExpired,VoucherExpireDate,CreatedAt,CreatedBy,UpdatedAt,UpadetedBy,Mdelete")] TblVoucherCode tblVoucherCode)
        {
            if (id != tblVoucherCode.VoucherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVoucherCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblVoucherCodeExists(tblVoucherCode.VoucherId))
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
            return View(tblVoucherCode);
        }

        // GET: VoucherCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVoucherCode = await _context.TblVoucherCodes
                .FirstOrDefaultAsync(m => m.VoucherId == id);
            if (tblVoucherCode == null)
            {
                return NotFound();
            }

            return View(tblVoucherCode);
        }

        // POST: VoucherCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVoucherCode = await _context.TblVoucherCodes.FindAsync(id);
            if (tblVoucherCode != null)
            {
                _context.TblVoucherCodes.Remove(tblVoucherCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblVoucherCodeExists(int id)
        {
            return _context.TblVoucherCodes.Any(e => e.VoucherId == id);
        }
    }
}
