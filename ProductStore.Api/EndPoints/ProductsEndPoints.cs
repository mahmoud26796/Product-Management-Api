namespace ProductStore.Api.EndPoints;

using MediatR;
using ProductStore.Api.Contracts.Queries.ProductsQueries;
using ProductStore.Api.Contracts.Commands.Products;

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
        group.MapGet("/", async (ISender sender) =>
        {
            var ProductsList = await sender.Send(new GetAllProducts());
            return ProductsList;
        });

        // get Product by id
        group.MapGet("/{id}", (Guid id, ISender sender) =>
        {
            var product = sender.Send(new GetProductById(id));
            return product;

        }).WithName(productsRouteName);

        // creating[posting] a new product
        group.MapPost("/", (ProductCommand command, ISender sender) =>
        {
            var product = sender.Send(command);
            return Results.CreatedAtRoute(productsRouteName, new { id = product.Id });
        });

        // Update an existing product info by Id
        group.MapPut("/{id}", async (Guid id, UpdateProductCommandId command, ISender sender) =>
        { /*
            in the Update Product we used a bit different approach so we can pass the correct id from the dbContext
            that matches the id in the route url so the id is authoritative — we don’t rely on the 
            client to send it in the body.
            also we do not need it in the update command record it self since that's no going to ba changed (the Id)
          */
            if (id == Guid.Empty) return Results.BadRequest();
            await sender.Send(new UpdateProductCommandId(id, command.Data));
            return Results.NoContent();
        });

        //delete[remove] a product by Id
        group.MapDelete("/{id}", async (Guid id, ISender sender) =>
        {

            await sender.Send(new DeleteProductById(id));
            return Results.NoContent();
        });

        return group;
    }
}