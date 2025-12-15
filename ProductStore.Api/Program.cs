using ProductStore.Api.Contracts;
using ProductStore.Api.Data;
using ProductStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connStr = "Data Source=GameStore.db";
// start registering services to Db 
// injecting services to the Db Context and Connect to the Databases with The Mapped Tables
builder.Services.AddSqlite<ProductStoreContext>(connStr);
app.MapProductsRoutes();

app.Run();
