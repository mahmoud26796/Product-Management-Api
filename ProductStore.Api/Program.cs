using ProductStore.Api.Contracts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string productsRouteName = "GetProduct";
List<ProductDto> products = [
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

// get all games
app.MapGet("products", () => products);

// get game by id
app.MapGet("products/{id}", (int id) => products.Find(p => p.Id == id)).WithName(productsRouteName);

// creating[posting] a new product
app.MapPost("products", (ProductDto newProduct) =>
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
app.MapPut("products/{id}", (int id, UpdateProductDto updatedProduct) =>
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
app.MapDelete("products/{id}", (int id) =>
{
    products.RemoveAll(p => p.Id == id);
    return Results.NoContent();
});

// roote route
app.MapGet("/", () => "Welcome To Supplement Store");

app.Run();
