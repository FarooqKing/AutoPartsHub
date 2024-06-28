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
    public class ItemSizesController : Controller
    {
        private readonly AutoPartsHubContext _context;

        public ItemSizesController(AutoPartsHubContext context)
        {
            _context = context;
        }

        // GET: ItemSizes
        public async Task<IActionResult> Index()
        {
            var AutoPartsHubContext = _context.TblItemSizes.Include(t => t.Item).Where(x => x.MDelete == false || x.MDelete == null);
            return View(await AutoPartsHubContext.ToListAsync());
        }

        // GET: ItemSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemSize = await _context.TblItemSizes
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (tblItemSize == null)
            {
                return NotFound();
            }

            return View(tblItemSize);
        }

        // GET: ItemSizes/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName");
            return View();
        }

        // POST: ItemSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeId,ItemId,ItemName,SizeName,SizeExtraAmount,IsDefaultSize,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItemSize tblItemSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblItemSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemSize.ItemId);
            return View(tblItemSize);
        }

        // GET: ItemSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemSize = await _context.TblItemSizes.FindAsync(id);
            if (tblItemSize == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemSize.ItemId);
            return View(tblItemSize);
        }

        // POST: ItemSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SizeId,ItemName,ItemId,SizeName,SizeExtraAmount,IsDefaultSize,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItemSize tblItemSize)
        {
            if (id != tblItemSize.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblItemSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblItemSizeExists(tblItemSize.SizeId))
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
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemSize.ItemId);
            return View(tblItemSize);
        }

        // GET: ItemSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemSize = await _context.TblItemSizes
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (tblItemSize == null)
            {
                return NotFound();
            }

            return View(tblItemSize);
        }

        // POST: ItemSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItemSize = await _context.TblItemSizes.FindAsync(id);
            if (tblItemSize != null)
            {
                tblItemSize.MDelete = true;
                _context.TblItemSizes.Update(tblItemSize);
            await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TblItemSizeExists(int id)
        {
            return _context.TblItemSizes.Any(e => e.SizeId == id);
        }
    }
}
