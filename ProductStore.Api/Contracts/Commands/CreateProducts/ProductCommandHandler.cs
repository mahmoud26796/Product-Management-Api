namespace ProductStore.Api.Contracts.Commands;

using MediatR;
using ProductStore.Api.Entities;
using ProductStore.Api.Data;
using ProductStore.Api.Mapping;
using ProductStore.Api.Contracts.Commands.CreateProducts;

public class ProductCommandHandler(ProductStoreContext dbContext) : IRequestHandler<ProductCommand, Product>
{
    private readonly ProductStoreContext dbContext = dbContext;

    public async Task<Product> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var product = Mapper.ToEntity(request);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        // return product;
        return product;
    }
}