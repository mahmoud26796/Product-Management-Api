using ProductStore.Api.Contracts;
using ProductStore.Api.Contracts.Commands.Products;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Mapping;

public class Mapper
{
    /*
        This Class Maps Between DTOs, Commands and Entities When Needed
    */
    public static Product ToEntity(Product product)
    {
        return new Product
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Price = product.Price,
            ExpDate = product.ExpDate

        };
    }

    public static Product ToEntity(UpdateProductCommand command)
    {
        return new Product
        {
            Name = command.Name,
            CategoryId = command.CategoryId,
            Price = command.Price,
            ExpDate = command.ExpDate
        };
    }

    public static Product ToEntity(ProductCommand command)
    {
        return new Product
        {
            Id = command.Id,
            Name = command.Name,
            CategoryId = command.CategoryId,
            Price = command.Price,
            ExpDate = command.ExpDate
        };
    }

    public static ProductDto ToDto(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name!,
            product.Category!.Name,
            product.Price,
            product.ExpDate
        );
    }

}