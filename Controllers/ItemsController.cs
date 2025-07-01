using Microsoft.AspNetCore.Mvc;
using UniBazaarLite.Data;
using UniBazaarLite.Filters;
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


        [ServiceFilter(typeof(ValidateEntityExistsFilter))]
        public IActionResult Details(int id)
        {
            var item = _repository.GetListingById(id);
            return View(item);
        }

        // /Items
        public IActionResult Index()
        {
            var items = _repository.GetListings();
            return View(items);
        }


        // GET: /Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Items/Create
        [HttpPost]
        public IActionResult Create(Listing listing)
        {
            if (!ModelState.IsValid)
                return View(listing);

            listing.SellerEmail = "admin@example.com"; // Simüle kullanıcı
            _repository.AddListing(listing);
            return RedirectToAction("Index");
        }
    }
}
