using Microsoft.EntityFrameworkCore;

namespace ApiProjeKampi.WebApi.Context
{
    public class ApiContext : DbContext
    {
        // 1. Program.cs'den gelecek olan konfigürasyonu kabul eden Constructor
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        // 2. OnConfiguring yerine bu parametreleri bağlantı dizene ekle
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-APFO5VL\\SQLEXPRESS;initial catalog=ApiYummyDb;integrated security=true;TrustServerCertificate=True;Encrypt=False;");
            }
        }

        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Chef> Chefs { get; set; }
        public DbSet<Entities.Contact> Contacts { get; set; }
        public DbSet<Entities.Feature> Features { get; set; }
        public DbSet<Entities.Image> Images { get; set; }
        public DbSet<Entities.Message> Messages { get; set; }
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Reservation> Reservations { get; set; }
        public DbSet<Entities.Service> Services { get; set; }
        public DbSet<Entities.Testimonial> Testimonials { get; set; }
    }
}