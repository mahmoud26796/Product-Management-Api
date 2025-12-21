using ProductStore.Api.Contracts;
using ProductStore.Api.Contracts.Commands;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Mapping;

public class Mapper
{
    /*
        This Class Maps Between DTOs and Entities When Needed
    */
    public static Product ToEntity(Product product)
    {
        return new Product
        {
            Name = product.Name,
            CatagoryId = product.CatagoryId,
            Price = product.Price,
            ExpDate = product.ExpDate

        };
    }

    public static Product ToEntity(UpdateProductDto updatedProduct, Guid id)
    {
        return new Product
        {
            Id = id,
            Name = updatedProduct.Name,
            CatagoryId = updatedProduct.CatagoryId,
            Price = updatedProduct.Price,
            ExpDate = updatedProduct.ExpDate

        };
    }

    public static ProductDto ToDto(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name!,
            product.Catagory!.Name,
            product.Price,
            product.ExpDate
        );
    }

    public static Product ToEntity(ProductCommand command)
    {
        return new Product
        {
            Id = command.Id,
            Name = command.Name,
            Catagory = command.Catagory,
            CatagoryId = command.CatagoryId,
            Price = command.Price,
            ExpDate = command.ExpDate
        };
    }
}