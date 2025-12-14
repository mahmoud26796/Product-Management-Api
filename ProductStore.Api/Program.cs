using ProductStore.Api.Contracts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapGet("products/{id}", (int id) => products.Find(p => p.Id == id));

// roote route
app.MapGet("/", () => "Welcome To Supplement Store");

app.Run();
