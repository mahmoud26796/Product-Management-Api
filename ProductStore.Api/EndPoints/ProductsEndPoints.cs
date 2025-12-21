namespace ProductStore.Api.EndPoints;

using Microsoft.EntityFrameworkCore;
using ProductStore.Api.Contracts;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;
using MediatR;
using ProductStore.Api.Contracts.Commands;
using ProductStore.Api.Contracts.Queries;

public static class ProductsEndPoints
{
    // route name
    const string productsRouteName = "GetProduct";

    //Extension Method to (Extend WebApp With Our Own Static Map Method)
    public static RouteGroupBuilder MapProductsRoutes(this WebApplication app)
    {
        //Grouping Routes 
        var group = app.MapGroup("products");
        // get all Products
        group.MapGet("/", (ProductStoreContext dbContext) => dbContext.Products.ToList());

        // get Product by id
        group.MapGet("/{id}", (Guid id, ProductStoreContext dbContext, ISender sender) =>
        {
            var product = sender.Send(new GetProductById(id));
            return Results.Ok(product);

        }).WithName(productsRouteName);

        // creating[posting] a new product
        group.MapPost("/", (ProductCommand command, ISender sender) =>
        {
            var product = sender!.Send(command);
            return Results.CreatedAtRoute(productsRouteName, new { id = product.Id });
        });

        // Update an existing product info by Id
        group.MapPut("/{id}", (Guid id, UpdateProductDto updatedProduct, ProductStoreContext dbContext) =>
        {

            var existingProduct = dbContext.Products.Find(id);
            if (existingProduct is null) return Results.NotFound();

            dbContext.Entry(existingProduct)
                .CurrentValues.SetValues(Mapper.ToEntity(updatedProduct, id));
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        //delete[remove] a product by Id
        group.MapDelete("/{id}", (Guid id, ProductStoreContext dbContext) =>
        {

            dbContext.Products.Where(p => p.Id == id).ExecuteDelete();
            dbContext.SaveChanges();
            return Results.NoContent();
        });

        return group;
    }
}