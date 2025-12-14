using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Contracts;

public record class CreateNewProductDto(
    [Required] int Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Catagory,
    [Required] double Price,
    [Required] DateOnly ExpDate
);