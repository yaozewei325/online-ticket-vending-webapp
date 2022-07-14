using BilletDeConcert.Models;
using Microsoft.EntityFrameworkCore;

namespace BilletDeConcert.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste_Concert>().HasKey(ac => new
            {
                ac.ArtisteId,
                ac.ConcertId
            });
            modelBuilder.Entity<Artiste_Concert>().HasOne(c => c.Concert).WithMany(ac => ac.Artiste_Concerts).HasForeignKey(ac => ac.ConcertId);
            modelBuilder.Entity<Artiste_Concert>().HasOne(a => a.Artiste).WithMany(ac => ac.Artiste_Concerts).HasForeignKey(ac => ac.ArtisteId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Artiste> Artistes{ get; set; }
        public DbSet<Concert> Concerts{ get; set; }

        public DbSet<Artiste_Concert> Artiste_Concerts{ get; set; }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem>ShoppingCartItems { get; set; }



    }
}
