using Microsoft.EntityFrameworkCore;

namespace FoodTeams.Entities
{
    public class FoodTeamsDbContext : DbContext
    {
        private string _connectionString =
           "Server=.;Database=FoodTeams3Db;Trusted_Connection=True;";
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(eb =>
            {
                eb.HasMany(x => x.Dishes).WithOne(y => y.Order);
                eb.Property(o => o.RestaurantName).IsRequired();
                eb.Property(o => o.DeliveryPrice).HasColumnType("decimal(5, 2)");
                eb.Property(o => o.FreeDeliveryPrice).HasColumnType("decimal(5, 2)");
                eb.Property(o => o.MinPrice).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Dish>(eb =>
            {
                eb.Property(d => d.Description).IsRequired();
                eb.Property(d => d.Price).IsRequired();
                eb.Property(o => o.Price).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<User>()
                 .HasMany(x => x.Dishes)
                 .WithOne(y => y.User);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
       // public DbSet<teamsProject.Models.OrderDto> OrderDto { get; set; }
    }
}
