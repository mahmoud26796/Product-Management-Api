using MediatR;
using ProductStore.Api.Data;

namespace ProductStore.Api.Contracts.Commands.Products;


public class DeleteProductHandler(ProductStoreContext dbContext) : IRequestHandler<DeleteProductById>
{
    private readonly ProductStoreContext _dbContext = dbContext;

    public async Task Handle(DeleteProductById request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(request.Id);
        if (product is null) return;

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}