using Microsoft.EntityFrameworkCore;
using pizza.Entity;

namespace pizza.Data
{
    public class PizzaDbContext: DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        public PizzaDbContext(DbContextOptions options)
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Entity.Pizza>()
                .HasIndex(p => p.ShortName).IsUnique();
        }
    }
}