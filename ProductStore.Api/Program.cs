using ProductStore.Api.Data;
using ProductStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("ProductStore");
// start registering services to Db 
// injecting services to the Db Context and Connect to the Databases with The Mapped Tables
builder.Services.AddSqlite<ProductStoreContext>(connStr);

var app = builder.Build();

// calling the Routes Mapping Method
app.MapProductsRoutes();

// calling the migrate method
app.MigrateDb();

app.Run();
