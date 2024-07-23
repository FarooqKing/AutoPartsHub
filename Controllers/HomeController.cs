using AutoPartsHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AutoPartsHub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AutoPartsHubContext _context;
		public HomeController(ILogger<HomeController> logger , AutoPartsHubContext context)
		{
			_logger = logger;
            _context = context;
		}

	
        public async Task<IActionResult> Index()
        {
            var items = await _context.TblItems.Include(x=>x.TblItemImages).ToListAsync();
            return View(items);
        }
        [Route("privacy")]
        public IActionResult Privacy()
		{
			return View();
		}

		[Route("about")]
		public IActionResult About()
		{
			return View();
		}
        [Route("shop")]
        public async Task<IActionResult> Shop()
        {
            var items = await _context.TblItems.Include(t => t.TblItemImages).ToListAsync();
            return View(items);
        }

        //public async Task<IActionResult> Shop()
        //public IActionResult Shop()
        //{
        //    //var items = await _context.GetAllItemsAsync();
        //    //return View(items);
        //    return View();
        //}
        [Route("blog")]
        public IActionResult Blog()
        {
            return View();
        }


        [Route("gallery")]
        public IActionResult Gallery()
        {
            return View();
        }



        //[Route("Pages")]
        public async Task<IActionResult> Pages()
        {
            var orderDetails = await _context.TblOrderDetails
                                             .Include(od => od.Item)
                                             .ThenInclude(item => item.TblItemImages)
                                             .ToListAsync();

            ViewData["ItemId"] = new SelectList(_context.TblItems, "ItemId", "ItemName");

            return View(orderDetails);
        }

        public IActionResult ContactUS()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUS([Bind("ContectUsId,ContectUsName,ContectUsEmail,ContectUsPhoneNo,ContectUsSubject,ContectUsMassage,mDelete")] TblContectU tblContact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tblContact);
                    await _context.SaveChangesAsync();

                }


                return View();
            }
            catch (Exception exp)
            {

                ViewBag.Message = exp.Message;
                return View(tblContact);
            }

        }
        [Route("itemDetail")]
        public async Task<IActionResult> ItemDetail(int id)
        {
            var item = await _context.TblItems.Include(t => t.TblOrderDetails).Include(t => t.TblItemImages)
                                              .FirstOrDefaultAsync(x => x.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        [Route("addToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int itemId, int quantity )
        {
            // Retrieve the item from the database
            var item = await _context.TblItems.Include(t => t.TblItemImages)
                                              .FirstOrDefaultAsync(x => x.ItemId == itemId);

            if (item == null)
            {
                return NotFound();
            }
            
            // Add the item to the order details (cart)
            var orderDetail = new TblOrderDetail
            {

                ItemId = itemId,
                ItemQuantity = quantity,
                TotelAmount = item.ItemPrice * quantity
            };

            _context.TblOrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Item added to cart successfully" });
        }








        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.TblOrderDetails
                                     .Include(t => t.Item)
                                     .FirstOrDefaultAsync(m => m.OrderDetailId== id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.TblOrderDetails.FindAsync(id);
            if (item != null)
            {
                item.MDelete = true;
                _context.TblOrderDetails.Update(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Pages", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
