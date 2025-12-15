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
}