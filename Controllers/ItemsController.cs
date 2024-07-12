using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoPartsHub.Models;
using Microsoft.Extensions.Hosting;

namespace AutoPartsHub.Controllers
{
    //[CustomAuthentication]
    //public class ItemsController : Controller
    //{
    //    private readonly AutoPartsHubContext _context;
    //    private readonly IWebHostEnvironment _hostEnvironment;
    //    public ItemsController(AutoPartsHubContext context, IWebHostEnvironment hostEnvironment)
    //    {
    //        _context = context;
    //        _hostEnvironment = hostEnvironment;
    //    }
    public class ItemsController : Controller
    {
        private readonly AutoPartsHubContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ItemsController(AutoPartsHubContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var AutoPartsHubContext =await  _context.TblItems.Include(t => t.Brand).ToListAsync();
            return View( AutoPartsHubContext);
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
        public async Task<IActionResult> Create([Bind("ItemId,ItemSlugs,DefaultImageFile,ItemName,ItemPrice,Discount,IsFeature,BrandId,Sku,DefaultImageUrl,ShortDescription,LongDescription,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                if (tblItem.DefaultImageFile != null)
                {

                    var fileName = Path.GetFileNameWithoutExtension(tblItem.DefaultImageFile.FileName);
                    var fileExtension = Path.GetExtension(tblItem.DefaultImageFile.FileName);
                    var Image = $"{fileName}_{Guid.NewGuid().ToString()}.{fileExtension}";

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string UploadedFolder = $"/Uploadimages/CategoryImages/";




                    var basePath = Path.Combine(wwwRootPath + UploadedFolder);



                    bool basePathExists = System.IO.Directory.Exists(basePath);



                    if (!basePathExists) Directory.CreateDirectory(basePath);



                    var filePath = Path.Combine(basePath, Image);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        tblItem.DefaultImageFile.CopyTo(stream);


                    }

                    string imageURL = UploadedFolder + Image;
                    tblItem.DefaultImageUrl = imageURL;
                }
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
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemSlugs,DefaultImageFile,ItemName,ItemPrice,Discount,IsFeature,BrandId,Sku,DefaultImageUrl,ShortDescription,LongDescription,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,MDelete")] TblItem tblItem)
        {
            if (id != tblItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (tblItem.DefaultImageFile != null)
                    {

                        var fileName = Path.GetFileNameWithoutExtension(tblItem.DefaultImageFile.FileName);
                        var fileExtension = Path.GetExtension(tblItem.DefaultImageFile.FileName);
                        var Image = $"{fileName}_{Guid.NewGuid().ToString()}.{fileExtension}";

                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string UploadedFolder = $"/Uploadimages/CategoryImages/";




                        var basePath = Path.Combine(wwwRootPath + UploadedFolder);



                        bool basePathExists = System.IO.Directory.Exists(basePath);



                        if (!basePathExists) Directory.CreateDirectory(basePath);



                        var filePath = Path.Combine(basePath, Image);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            tblItem.DefaultImageFile.CopyTo(stream);


                        }

                        string imageURL = UploadedFolder + Image;
                        tblItem.DefaultImageUrl = imageURL;
                    }
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
                tblItem.MDelete = true;
                _context.TblItems.Update(tblItem);
            await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TblItemExists(int id)
        {
            return _context.TblItems.Any(e => e.ItemId == id);
        }
    }
}
