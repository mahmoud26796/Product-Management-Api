using ProductStore.Api.Data;
using ProductStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("ProductStore");
// start registering services to Db 
// injecting services to the Db Context and Connect to the Databases with The Mapped Tables
builder.Services.AddSqlite<ProductStoreContext>(connStr);
// Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger in Dev Env
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Serves the Swagger JSON document
    app.UseSwaggerUI(); // Serves the Swagger UI
}

// calling the Routes Mapping Method
app.MapProductsRoutes();

// calling the migrate method
app.MigrateDb();

app.Run();
