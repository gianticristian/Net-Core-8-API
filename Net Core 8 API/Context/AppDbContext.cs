using Microsoft.EntityFrameworkCore;
using Net_Core_8_API.Models;

namespace Net_Core_8_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
