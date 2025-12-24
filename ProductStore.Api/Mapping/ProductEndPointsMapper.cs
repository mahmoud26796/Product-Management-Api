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
            Category = product.Category,
            Price = product.Price,
            ExpDate = product.ExpDate

        };
    }

    public static Product ToEntity(UpdateProductDto command)
    {
        return new Product
        {
            Name = command.Name,
            CategoryId = command.CategoryId,
            Price = command.Price,
            ExpDate = command.ExpDate
        };
    }
    public static Product ToEntity(UpdateProductCommandId command)
    {
        return new Product
        {
            Id = command.Id,
            Name = command.Data.Name,
            CategoryId = command.Data.CategoryId,
            Category = command.Data.Category,
            Price = command.Data.Price,
            ExpDate = command.Data.ExpDate
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