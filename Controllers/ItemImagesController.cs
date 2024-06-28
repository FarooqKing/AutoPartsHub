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
    public class ItemImagesController : Controller
    {
        private readonly AutoPartsHubContext _context;

        public ItemImagesController(AutoPartsHubContext context)
        {
            _context = context;
        }

        // GET: ItemImages
        public async Task<IActionResult> Index()
        {
            var AutoPartsHubContext = _context.TblItemImages.Include(t => t.Item).Where(x => x.MDelete == false || x.MDelete == null);
            return View(await AutoPartsHubContext.ToListAsync());
        }

        // GET: ItemImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemImage = await _context.TblItemImages
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.ItemImageId == id);
            if (tblItemImage == null)
            {
                return NotFound();
            }

            return View(tblItemImage);
        }

        // GET: ItemImages/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName");
            return View();
        }

        // POST: ItemImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemImageId,ItemImageName,ThumbailImage,NormalImage,IsDefault,ItemId,ItemName,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete,BanerImage")] TblItemImage tblItemImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblItemImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemImage.ItemId);
            return View(tblItemImage);
        }

        // GET: ItemImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemImage = await _context.TblItemImages.FindAsync(id);
            if (tblItemImage == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemImage.ItemId);
            return View(tblItemImage);
        }

        // POST: ItemImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemImageId,ItemName,ItemImageName,ThumbailImage,NormalImage,IsDefault,ItemId,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete,BanerImage")] TblItemImage tblItemImage)
        {
            if (id != tblItemImage.ItemImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblItemImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblItemImageExists(tblItemImage.ItemImageId))
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
            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName", tblItemImage.ItemId);
            return View(tblItemImage);
        }

        // GET: ItemImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemImage = await _context.TblItemImages
                .Include(t => t.Item)
                .FirstOrDefaultAsync(m => m.ItemImageId == id);
            if (tblItemImage == null)
            {
                return NotFound();
            }

            return View(tblItemImage);
        }

        // POST: ItemImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItemImage = await _context.TblItemImages.FindAsync(id);
            if (tblItemImage != null)
            {
                tblItemImage.MDelete = true;
                _context.TblItemImages.Update(tblItemImage);
            await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TblItemImageExists(int id)
        {
            return _context.TblItemImages.Any(e => e.ItemImageId == id);
        }
    }
}
