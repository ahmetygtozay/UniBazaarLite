using UniBazaarLite.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UniBazaarLite.Data
{
    public class InMemoryRepository : IRepository
    {
        // In-memory list to store events
        private readonly List<Event> _events = new();
        // In-memory list to store listings (items)
        private readonly List<Listing> _listings = new();

        // Counters for generating unique IDs
        private int _eventId = 2;   // Event with ID=1 already added in constructor
        private int _listingId = 1;

        // Constructor - seed with one default event
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

        // Returns the list of all events
        public List<Event> GetEvents() => _events;

        // Finds and returns an event by ID, or null if not found
        public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);

        // Adds a new event, assigning a unique ID
        public void AddEvent(Event evt)
        {
            evt.Id = _eventId++;
            _events.Add(evt);
        }

        // Updates an existing event, if it exists
        public void UpdateEvent(Event evt)
        {
            var index = _events.FindIndex(e => e.Id == evt.Id);
            if (index != -1)
                _events[index] = evt;
        }

        // Returns the list of all listings (items)
        public List<Listing> GetListings()
        {
            Console.WriteLine($"Total listings: {_listings.Count}"); // Debug output
            return _listings;
        }

        // Finds and returns a listing by ID, or null if not found
        public Listing? GetListingById(int id) => _listings.FirstOrDefault(l => l.Id == id);

        // Adds a new listing, assigning a unique ID
        public void AddListing(Listing listing)
        {
            listing.Id = _listingId++;
            _listings.Add(listing);
            Console.WriteLine($"Listing added: {listing.Title}, Price: {listing.Price}"); // Debug output
        }

        // Returns the next event ID (mainly for use by event creation pages)
        public int GetNextEventId()
        {
            return _eventId;
        }
    }
}
