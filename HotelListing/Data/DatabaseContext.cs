using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
    
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //Defining a database table called Countries
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
