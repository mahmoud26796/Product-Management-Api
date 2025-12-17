namespace ProductStore.Api.EndPoints;

using ProductStore.Api.Contracts;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;

public static class ProductsEndPoints
{
    // 1) data List
    const string productsRouteName = "GetProduct";
    static readonly List<ProductDto> products = [
        new(
        1,
        "Gold Standarr",
        "Protiens",
        150.50,
        new DateOnly(2026, 1, 1)
        ),
        new(
            2,
            "Drive Creatine",
            "Performance",
            11.50,
            new DateOnly(2026, 1, 1)
        ),
        new(
            3,
            "Animal Pak",
            "Vitamins",
            80.50,
            new DateOnly(2026, 1, 1)
        ),
    ];

    // 2) Extension Method to (Extend WebApp With Our Own Static Map Method)
    public static RouteGroupBuilder MapProductsRoutes(this WebApplication app)
    {
        //Grouping Routes 
        var group = app.MapGroup("products");
        // get all games
        group.MapGet("/", () => products);

        // get game by id
        group.MapGet("/{id}", (int id) => products.Find(p => p.Id == id)).WithName(productsRouteName);

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
        group.MapPut("/{id}", (int id, UpdateProductDto updatedProduct) =>
        {
            var index = products.FindIndex(p => p.Id == id);
            products[index] = new ProductDto(
               id,
               updatedProduct.Name,
               updatedProduct.Catagory,
               updatedProduct.Price,
               updatedProduct.ExpDate
            );

            return Results.NoContent();
        });

        //delete[remove] a product by Id
        group.MapDelete("/{id}", (int id) =>
        {
            products.RemoveAll(p => p.Id == id);
            return Results.NoContent();
        });

        // roote route
        return group;
    }
}