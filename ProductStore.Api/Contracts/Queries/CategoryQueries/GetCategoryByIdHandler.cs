namespace ProductStore.Api.Contracts.Queries.CategoryQueries;

using MediatR;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;

public class GetCategoryByIdHandler(ProductStoreContext dbContext) : IRequestHandler<GetCategoryById, Category>
{
    private readonly ProductStoreContext _dbContext = dbContext;

    public async Task<Category> Handle(GetCategoryById req, CancellationToken ct)
    {
        var category = await _dbContext.Catagories.FindAsync(req.Id, ct) ?? throw new Exception("Category Not Found");
        return category;
    }
}