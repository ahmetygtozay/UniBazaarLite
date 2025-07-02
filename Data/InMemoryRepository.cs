using UniBazaarLite.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UniBazaarLite.Data
{


    public class InMemoryRepository : IRepository
    {
        private readonly List<Event> _events = new();
        private readonly List<Listing> _listings = new();
        private int _eventId = 2;   // 1 zaten eklendi
        private int _listingId = 1;


        public InMemoryRepository()
        {
            _events.Add(new Event
            {
                Id = 1,
                Title = "Welcome Event",
                Description = "Welcome to UniBazaar!",
                Date = DateTime.Today.AddDays(3)
            });
        }

        public List<Event> GetEvents() => _events;

        public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public void AddEvent(Event evt)
        {
            evt.Id = _eventId++;
            _events.Add(evt);
        }

        public void UpdateEvent(Event evt)
        {
            var index = _events.FindIndex(e => e.Id == evt.Id);
            if (index != -1)
                _events[index] = evt;
        }

        public List<Listing> GetListings()
        {
            Console.WriteLine($"Total listings: {_listings.Count}");
            return _listings;
        }

        public Listing? GetListingById(int id) => _listings.FirstOrDefault(l => l.Id == id);

        public void AddListing(Listing listing)
        {
            listing.Id = _listingId++;
            _listings.Add(listing);
            Console.WriteLine($"Listing added: {listing.Title}, Price: {listing.Price}");
        }

        public int GetNextEventId()
        {
            return _eventId;
        }
    }
}
