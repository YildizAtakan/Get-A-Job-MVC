using System.Data.Entity;
using getajob.Models;

namespace getajob.Data
{
    public class ListingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ListingContext() : base("name=ListingContext")
        {
        }

        public DbSet<Listing> Listings { get; set; }
    }
}