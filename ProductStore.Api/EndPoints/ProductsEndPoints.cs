namespace ProductStore.Api.EndPoints;

using Microsoft.EntityFrameworkCore;
using ProductStore.Api.Contracts;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;

public static class ProductsEndPoints
{
    const string productsRouteName = "GetProduct";
    // 2) Extension Method to (Extend WebApp With Our Own Static Map Method)
    public static RouteGroupBuilder MapProductsRoutes(this WebApplication app)
    {
        //Grouping Routes 
        var group = app.MapGroup("products");
        // get all Products
        group.MapGet("/", (ProductStoreContext dbContext) => dbContext.Products.ToList());

        // get Product by id
        group.MapGet("/{id}", (int id, ProductStoreContext dbContext) =>
        {
            // getting the Product From The Databases
            Product? productById = dbContext.Products.Find(id);

            if (productById is null)
                return Results.NotFound();
            Product product = Mapper.ToEntity(productById);
            product.Catagory = dbContext.Catagories.Find(productById.CatagoryId);
            return Results.Ok(product);
            /*
                Nore: Results is a Class That is Extended From Abstract ActionResult 
                Which Allow to Return Responses From Our Controller
            */

        }).WithName(productsRouteName);

        // creating[posting] a new product
        group.MapPost("/", (Product newProduct, ProductStoreContext dbContext) =>
        {
            // making a new Entity for the db context
            Product product = Mapper.ToEntity(newProduct);
            product.Catagory = dbContext.Catagories.Find(newProduct.CatagoryId);

            // adding the new Product to the db context and save the changes to the db
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            // creating a productDto to be returned in the response body
            ProductDto productDto = Mapper.ToDto(product);
            return Results.CreatedAtRoute(productsRouteName, new { id = product.Id }, productDto);
        });

        // Update an existing product info by Id
        group.MapPut("/{id}", (int id, UpdateProductDto updatedProduct, ProductStoreContext dbContext) =>
        {

            var existingProduct = dbContext.Products.Find(id);
            if (existingProduct is null) return Results.NotFound();

            dbContext.Entry(existingProduct)
                .CurrentValues.SetValues(Mapper.ToEntity(updatedProduct, id));
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        //delete[remove] a product by Id
        group.MapDelete("/{id}", (int id, ProductStoreContext dbContext) =>
        {
            dbContext.Products.Where(p => p.Id == id).ExecuteDelete();
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        return group;
    }
}