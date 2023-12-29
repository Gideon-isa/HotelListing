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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(

                new Country()
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName = "NG"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Uganda",
                    ShortName = "UG"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Rwanda",
                    ShortName = "RD"
                }

            );

            modelBuilder.Entity<Hotel>().HasData(

                new Hotel()
                {
                    Id = 1,
                    Name = "EKo Hotel and Suits",
                    Address =  "Victoria Island",
                    CountryId = 1,
                    Ratings = 5
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Uganda Premium Line",
                    Address = "Kampla Heights",
                    CountryId = 2,
                    Ratings = 4
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "Rwanda KWR",
                    Address = "Rwanda Capitol",
                    CountryId = 3,
                    Ratings = 4.5
                }

            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
