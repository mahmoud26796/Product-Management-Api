using MediatR;
using ProductStore.Api.Data;
using ProductStore.Api.Entities;
using ProductStore.Api.Mapping;

namespace ProductStore.Api.Contracts.Commands.Products;


public class UpdateProductCommandHandler(ProductStoreContext dbContext) : IRequestHandler<UpdateProductCommandId>
{
    private readonly ProductStoreContext _dbContext = dbContext;

    public async Task Handle(UpdateProductCommandId request, CancellationToken ct)
    {
        var existingProduct = await _dbContext.Products.FindAsync(request.Id, ct) ?? throw new Exception("Product Not Found");
        _dbContext.Entry(existingProduct).CurrentValues.SetValues(Mapper.ToEntity(request.Data));
        await _dbContext.SaveChangesAsync(ct);
    }
}