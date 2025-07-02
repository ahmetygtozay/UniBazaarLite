using Microsoft.AspNetCore.Mvc;
using UniBazaarLite.Data;
using UniBazaarLite.Filters;
using UniBazaarLite.Models;
using UniBazaarLite.Services;  // CurrentUser için

namespace UniBazaarLite.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IRepository _repository;
        private readonly CurrentUser _currentUser;

        public ItemsController(IRepository repository, CurrentUser currentUser)
        {
            _repository = repository;
            _currentUser = currentUser;
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
            if (!_currentUser.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: /Items/Create
        [HttpPost]
        public IActionResult Create(Listing listing)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse formu tekrar göster
                return View(listing);
            }

            // Simüle edilen kullanıcı emaili
            listing.SellerEmail = _currentUser.Email;

            _repository.AddListing(listing);

            // İşlem başarılıysa liste sayfasına yönlendir
            return RedirectToAction("Index");
        }
    }
}
