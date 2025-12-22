namespace ProductStore.Api.EndPoints;

using MediatR;
using ProductStore.Api.Contracts.Commands;

public static class CategoryEndPoints
{
    public static RouteGroupBuilder MapCategoryRoutes(this WebApplication app)
    {
        var group = app.MapGroup("api/categories");
        // get All categories
        group.MapGet("/", () => { });

        //get Category By Id
        group.MapGet("/{id}", (int id) => { });

        group.MapPost("/", (CreateCategoryCommand command, ISender sender) =>
        {
            var category = sender.Send(command);
            return Results.Ok(category);
        });


        return group;
    }
}