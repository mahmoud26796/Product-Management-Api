using Microsoft.EntityFrameworkCore;

namespace ProductStore.Api.Data;

using ProductStore.Api.Entities;

public class ProductStoreContext(DbContextOptions<ProductStoreContext> options)
: DbContext(options) // inheriting context options from the super class DbContext
{
    // Maps To Products Table in DB Context
    public DbSet<Product> Products => Set<Product>();

    // Maps To Catagories Table in DB Context
    public DbSet<Catagory> Catagories => Set<Catagory>();

    // seeding data so when application runs migrations those basic data will be always there to start with
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catagory>().HasData(
            new { Id = 1, Name = "Performace" },
            new { Id = 2, Name = "Protiens" },
            new { Id = 3, Name = "Vitamins" }
        );
    }
}