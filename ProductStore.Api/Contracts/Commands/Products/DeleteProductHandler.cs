using MediatR;
using ProductStore.Api.Data;

namespace ProductStore.Api.Contracts.Commands.Products;


public class DeleteProductHandler(ProductStoreContext dbContext) : IRequestHandler<DeleteProductById>
{
    private readonly ProductStoreContext _dbContext = dbContext;

    public async Task Handle(DeleteProductById request, CancellationToken ct)
    {
        var product = await _dbContext.Products.FindAsync(request.Id, ct) ?? throw new Exception("Prodcut Not Found");
        var categoryId = product.CategoryId;

        var category = await _dbContext.Categories.FindAsync([categoryId]) ?? throw new Exception("category not found");
        category.ProductsCount--;
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(ct);
    }
}