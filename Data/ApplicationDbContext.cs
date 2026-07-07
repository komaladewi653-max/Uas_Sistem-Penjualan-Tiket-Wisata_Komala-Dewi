using Microsoft.EntityFrameworkCore;
using WisataTicketApp.Models;

namespace WisataTicketApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Wisata> Wisatas { get; set; }

        public DbSet<Pengunjung> Pengunjungs { get; set; }
        public DbSet<Pemesanan> Pemesanans { get; set; }
        
        
    }
}
