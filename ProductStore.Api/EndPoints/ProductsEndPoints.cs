namespace ProductStore.Api.EndPoints;

using ProductStore.Api.Contracts;


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
    public static RouteGroupBuilder MapProductsRoutes(this WebApplication app)
    {
        //Grouping Routes 
        var group = app.MapGroup("products");
        // get all games
        group.MapGet("/", () => products);

        // get game by id
        group.MapGet("/{id}", (int id) => products.Find(p => p.Id == id)).WithName(productsRouteName);

        // creating[posting] a new product
        group.MapPost("/", (ProductDto newProduct) =>
        {
            ProductDto product = new(
                products.Count + 1,
                newProduct.Name,
                newProduct.Catagory,
                newProduct.Price,
                newProduct.ExpDate

            );

            products.Add(product);

            return Results.CreatedAtRoute(productsRouteName, new { id = product.Id }, product);
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