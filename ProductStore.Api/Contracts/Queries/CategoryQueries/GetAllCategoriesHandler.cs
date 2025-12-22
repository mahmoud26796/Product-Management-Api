using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Contracts.Queries.CategoryQueries;

public class GetAllCategoriesHandler(ProductStoreContext dbContext) : IRequestHandler<GetAllCategories, List<Category>>
{
    private readonly ProductStoreContext _dbContext = dbContext;
    public async Task<List<Category>> Handle(GetAllCategories req, CancellationToken ct)
    {
        var Categories = await _dbContext.Catagories.AsNoTracking().Select(c => new Category { Id = c.Id, Name = c.Name }).ToListAsync(ct);
        return Categories;
    }
}