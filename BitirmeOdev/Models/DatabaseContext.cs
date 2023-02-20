using Microsoft.EntityFrameworkCore;

namespace BitirmeOdev.Models
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
        }

        public DbSet<Kullanici> Kullanici { get; set; }

    }
}
