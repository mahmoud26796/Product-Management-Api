namespace ProductStore.Api.Contracts.Commands.Products;

using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductStore.Api.Entities;



public record class ProductCommand(
    [Required] Guid Id,
    [Required][StringLength(50)] string Name,
    [Required] int CategoryId,
    [Required] Category Category,
    [Required] double Price,
    [Required] DateOnly ExpDate
) : IRequest<Product>;