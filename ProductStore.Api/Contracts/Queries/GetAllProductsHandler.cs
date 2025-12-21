using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;

namespace ProductStore.Api.Contracts.Queries;

public class GetAllProductsHandler(ProductStoreContext dbContext) : IRequestHandler<GetAllProducts, List<Product>>
{
    private readonly ProductStoreContext _dbContext = dbContext;
    public async Task<List<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
    {
        var products = await _dbContext.Products.Select(p => Mapper.ToEntity(p)).ToListAsync();
        return products;
    }
}