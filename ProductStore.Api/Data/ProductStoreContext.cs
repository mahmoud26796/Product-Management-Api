using Microsoft.EntityFrameworkCore;

namespace ProductStore.Api.Data;

using ProductStore.Api.Entities;

public class ProductStoreContext(DbContextOptions<ProductStoreContext> options)
: DbContext(options) // inheriting context options from the super class DbContext
{
    // Maps To Products Table in DB Context
    public DbSet<Product> Products => Set<Product>();

    // Maps To Catagories Table in DB Context
    public DbSet<Category> Catagories => Set<Category>();

    // seeding data so when application runs migrations those basic data will be always there to start with
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // creating each catagory name with the associated Id
        modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Protiens" },
            new { Id = 2, Name = "Performace" },
            new { Id = 3, Name = "Vitamins" }
        );
    }
}