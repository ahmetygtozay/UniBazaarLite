using Microsoft.AspNetCore.Mvc;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IRepository _repository;

        public ItemsController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var items = _repository.GetListings();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Listing listing)
        {
            if (!ModelState.IsValid)
                return View(listing);

            listing.SellerEmail = "admin@unibazaar.com";
            _repository.AddListing(listing);

            /* return RedirectToAction("Index");  */
            return Json(listing);
            

        }
    }
}
