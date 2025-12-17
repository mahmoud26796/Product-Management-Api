using ProductStore.Api.Contracts;
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
}