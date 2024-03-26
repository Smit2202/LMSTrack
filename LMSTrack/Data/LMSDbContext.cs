using Microsoft.EntityFrameworkCore;
using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=LMSdB;Trusted_Connection=True;Integrated Security=True;Timeout=60;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            }
        }

        // DbSet properties for your entities
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
