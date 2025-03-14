using Microsoft.EntityFrameworkCore;
using FINAL_ELNET.Models;

namespace FINAL_ELNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterModel> Users { get; set; }
        
        // Define your DbSet properties here
        // Example:
        // public DbSet<YourModel> YourModels { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure RegisterModel entity
            modelBuilder.Entity<RegisterModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Add your entity configurations here
                // For example:
                // entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                // entity.HasIndex(e => e.Email).IsUnique();
            });
            
            // Add additional entity configurations as needed
        }
    }
}
