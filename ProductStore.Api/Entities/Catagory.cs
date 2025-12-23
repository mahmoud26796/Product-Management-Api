namespace ProductStore.Api.Entities;

public class Category
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int ProductsCount { get; set; } = 0;
}