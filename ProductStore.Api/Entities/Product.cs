namespace ProductStore.Api.Entities;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public int CatagoryId { get; set; }

    public Catagory? Catagory { get; set; }

    public double Price { get; set; }

    public DateOnly ExpDate { get; set; }

}