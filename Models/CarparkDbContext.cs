namespace CarparkInfo.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CarparkDbContext : DbContext
    {
        // Define the Carpark table
        public DbSet<Carpark> Carparks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the SQLite database connection string
            optionsBuilder.UseSqlite("Data Source=carpark.db");
        }
    }
}
