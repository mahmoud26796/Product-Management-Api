using Microsoft.EntityFrameworkCore;

namespace ProductStore.Api.Data;

public static class DataExtenstions
{
    // 1) MigrateDb Method => creating Migrations Automatically when app runs
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();

        // do the migration in the Db Context
        dbContext.Database.Migrate();
    }
}