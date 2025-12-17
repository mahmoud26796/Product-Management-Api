using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Contracts;

public record class UpdateProductDto(
    [Required][StringLength(50)] string Name,
    [Required] int CatagoryId,
    [Required] double Price,
    [Required] DateOnly ExpDate
);