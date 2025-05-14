using Microsoft.EntityFrameworkCore;
using TravelAgent.Models;

namespace TravelAgent.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){ }

        public DbSet<TravelPackages> TravelPackages { get; set; }

        
    }
}
