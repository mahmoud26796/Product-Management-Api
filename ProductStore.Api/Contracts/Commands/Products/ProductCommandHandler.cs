namespace ProductStore.Api.Contracts.Commands.Products;

using MediatR;
using ProductStore.Api.Entities;
using ProductStore.Api.Data;
using ProductStore.Api.Mapping;

public class ProductCommandHandler(ProductStoreContext dbContext) : IRequestHandler<ProductCommand, Product>
{
    private readonly ProductStoreContext dbContext = dbContext;

    public async Task<Product> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var product = Mapper.ToEntity(request);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        // return product;
        return product;
    }
}