using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
    public class BestRestaurantsContext : DbContext
    {
        public DbSet<Cuisine> Cuisines {get;set;} //add virtual
        // public DbSet<Item> Items {get;set;}
        public BestRestaurantsContext(DbContextOptions options) : base(options) {}
    }
}