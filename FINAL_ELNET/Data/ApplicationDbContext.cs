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

        public DbSet<ReservationViewModel> Reservations { get; set; }
    }
}