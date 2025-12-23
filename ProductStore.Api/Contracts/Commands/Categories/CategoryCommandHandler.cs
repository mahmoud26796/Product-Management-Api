namespace ProductStore.Api.Contracts.Commands.Categories;

using MediatR;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;

public class CreateCategoryCommandHandler(ProductStoreContext dbContext) : IRequestHandler<CreateCategoryCommand, Category>
{
    private readonly ProductStoreContext _dbContext = dbContext;
    public async Task<Category> Handle(CreateCategoryCommand req, CancellationToken ct)
    {
        var Category = new Category { Id = req.Id, Name = req.Name };
        _dbContext.Categories.Add(Category);
        await _dbContext.SaveChangesAsync(ct);
        return Category;
    }
}
