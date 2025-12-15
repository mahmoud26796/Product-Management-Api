using ProductStore.Api.Contracts;
using ProductStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapProductsRoutes();

app.Run();
