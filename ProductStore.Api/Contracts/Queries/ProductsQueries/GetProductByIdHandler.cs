namespace ProductStore.Api.Contracts.Queries;

using MediatR;
using ProductStore.Api.Contracts.Queries.ProductsQueries;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;

public class GetProductByIdHandler(ProductStoreContext dbContext) : IRequestHandler<GetProductById, Product>
{
    // declaring our dbContext
    private readonly ProductStoreContext _dbcontext = dbContext;
    public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        // getting the Product From The Databases
        Product? productById = await _dbcontext.Products.FindAsync(request.Id);
        if (productById is null) throw new Exception("Product Not Found");
        Product product = Mapper.ToEntity(productById);
        return product;
    }
}