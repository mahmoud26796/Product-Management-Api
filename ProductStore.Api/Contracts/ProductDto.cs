using System.ComponentModel.DataAnnotations;

namespace ProductStore.Api.Contracts;

public record class ProductDto(
    [Required] Guid Id,
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Category,
    [Required] double Price,
    [Required] DateOnly ExpDate
);