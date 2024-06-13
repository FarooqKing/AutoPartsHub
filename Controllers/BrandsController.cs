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
    public class BrandsController : Controller
    {
        private readonly AutoPartsHubContext _context;

        public BrandsController(AutoPartsHubContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
            var brands = await _context.TblBrands
            .Where(b => b.MDelete != null && b.MDelete == false)
          .ToListAsync();
            return View(brands);
        }


        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBrand = await _context.TblBrands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (tblBrand == null)
            {
                return NotFound();
            }

            return View(tblBrand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName,BrandTitle,BrandShortName,BrandDescription,BrandImage,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblBrand tblBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBrand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBrand = await _context.TblBrands.FindAsync(id);
            if (tblBrand == null)
            {
                return NotFound();
            }
            return View(tblBrand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName,BrandTitle,BrandShortName,BrandDescription,BrandImage,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblBrand tblBrand)
        {
            if (id != tblBrand.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBrandExists(tblBrand.BrandId))
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
            return View(tblBrand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBrand = await _context.TblBrands
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (tblBrand == null)
            {
                return NotFound();
            }

            return View(tblBrand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBrand = await _context.TblBrands.FindAsync(id);
            if (tblBrand != null)
            {
                tblBrand.MDelete = true; // Set the soft delete flag to true
                _context.TblBrands.Update(tblBrand); // Mark the entity as modified
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        private bool TblBrandExists(int id)
        {
            return _context.TblBrands.Any(e => e.BrandId == id);
        }
    }
}
