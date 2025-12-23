namespace ProductStore.Api.EndPoints;

using MediatR;
using ProductStore.Api.Contracts.Commands.Categories;
using ProductStore.Api.Contracts.Queries.CategoryQueries;

public static class CategoryEndPoints
{
    public static RouteGroupBuilder MapCategoryRoutes(this WebApplication app)
    {
        var group = app.MapGroup("api/categories");
        // get All categories
        group.MapGet("/", (ISender sender) =>
        {
            var categories = sender.Send(new GetAllCategories());
            return Results.Ok(categories);
        });

        //get Category By Id
        group.MapGet("/{id}", (int id, ISender sender) =>
        {
            var category = sender.Send(new GetCategoryById(id));
            return Results.Ok(category);
        });

        // create new product
        group.MapPost("/", (CreateCategoryCommand command, ISender sender) =>
        {
            var category = sender.Send(command);
            return Results.Ok(category);
        });


        return group;
    }
}