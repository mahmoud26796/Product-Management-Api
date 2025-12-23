namespace ProductStore.Api.Contracts.Commands.Products;

using MediatR;
using ProductStore.Api.Entities;
using ProductStore.Api.Data;
using ProductStore.Api.Mapping;
using ProductStore.Api.Contracts.Queries.CategoryQueries;

public class ProductCommandHandler(ProductStoreContext dbContext) : IRequestHandler<ProductCommand, Product>
{
    private readonly ProductStoreContext dbContext = dbContext;

    public async Task<Product> Handle(ProductCommand request, CancellationToken ct)
    {
        var product = Mapper.ToEntity(request);
        dbContext.Products.Add(product);
        /*
            getting the associated category with this new product from the dbContext 
            by the category id from the request object
        */
        var categoryInDb = await dbContext.Categories.FindAsync([request.CategoryId], ct);
         if (categoryInDb is not null) categoryInDb.ProductsCount++;

        await dbContext.SaveChangesAsync(ct);
        // return product;
        return product;
    }
}