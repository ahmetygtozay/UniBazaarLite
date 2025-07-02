using UniBazaarLite.Models;

namespace UniBazaarLite.Data
{
    public interface IRepository
    {
        // Events
        List<Event> GetEvents();
        Event? GetEventById(int id);
        void AddEvent(Event evt);
        void UpdateEvent(Event evt);

        // Listings
        List<Listing> GetListings();
        Listing? GetListingById(int id);
        void AddListing(Listing listing);

        
        int GetNextEventId();
    }
}
