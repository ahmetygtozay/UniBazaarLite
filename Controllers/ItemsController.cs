using Microsoft.AspNetCore.Mvc;
using UniBazaarLite.Data;
using UniBazaarLite.Models;

namespace UniBazaarLite.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IRepository _repository;

        // Constructor to inject the IRepository service for data access
        public ItemsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /Items
        // Action to list all items
        public IActionResult Index()
        {
            var items = _repository.GetListings(); // Retrieve all listings from the repository
            return View(items); // Pass the list to the view
        }

        // GET: /Items/Create
        // Action to display the form for creating a new item
        public IActionResult Create()
        {
            return View(); // Return an empty form view
        }

        // POST: /Items/Create
        // Action to receive new item data and save it
        [HttpPost]
        public IActionResult Create([FromBody] Listing listing)
        {
            // If model validation fails, return the form with the entered data
            if (!ModelState.IsValid)
                return View(listing);

            // Assign a simulated seller email
            listing.SellerEmail = "admin@unibazaar.com";

            // Add the new listing to the repository
            _repository.AddListing(listing);

            /*
             * Normally, we would redirect to the index page after creation:
             * return RedirectToAction("Index");
             * But here, we return JSON to support AJAX calls on the frontend.
             */
            return Json(listing); // Return the created listing as JSON
        }
    }
}
