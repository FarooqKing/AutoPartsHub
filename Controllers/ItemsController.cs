using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoHubFYP.Models;

namespace AutoHubFYP.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AutoPartsHubContext _context;

        public ItemsController(AutoPartsHubContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var autoPartsHubContext =await  _context.TblItems.Include(t => t.Brand).ToListAsync();
            return View( autoPartsHubContext);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await _context.TblItems
                .Include(t => t.Brand)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (tblItem == null)
            {
                return NotFound();
            }

            return View(tblItem);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "BrandId", "BrandName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemSlugs,ItemName,ItemPrice,Discount,IsFeature,BrandId,Sku,DefaultImageUrl,ShortDescription,LongDescription,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "BrandId", "BrandName", tblItem.BrandId);
            return View(tblItem);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await _context.TblItems.FindAsync(id);
            if (tblItem == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "BrandId", "BrandName", tblItem.BrandId);
            return View(tblItem);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemSlugs,ItemName,ItemPrice,Discount,IsFeature,BrandId,Sku,DefaultImageUrl,ShortDescription,LongDescription,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItem tblItem)
        {
            if (id != tblItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblItemExists(tblItem.ItemId))
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
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "BrandId", "BrandName", tblItem.BrandId);
            return View(tblItem);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await _context.TblItems
                .Include(t => t.Brand)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (tblItem == null)
            {
                return NotFound();
            }

            return View(tblItem);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItem = await _context.TblItems.FindAsync(id);
            if (tblItem != null)
            {
                _context.TblItems.Remove(tblItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblItemExists(int id)
        {
            return _context.TblItems.Any(e => e.ItemId == id);
        }
    }
}
