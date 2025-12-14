using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Contracts;

public record class ProductDto(
    [Required] int Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Catagory,
    [Required] double Price,
    [Required] DateOnly ExpDate
);