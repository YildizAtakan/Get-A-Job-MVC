using System.Data.Entity;

namespace getajob.Models

{
    public class Listing
    {
        public int ID { get; set; }
        public string ListingCreator { get; set; }
        public string ListingName { get; set; }
        public string ListingCompany { get; set; }
        public string listingPicture { get; set; }
        public string listingText { get; set; }
        public string listingContact { get; set; }

        public class ListingDBContext : DbContext
        {
            public DbSet<Listing> Listing { get; set; }
        }
    }
}