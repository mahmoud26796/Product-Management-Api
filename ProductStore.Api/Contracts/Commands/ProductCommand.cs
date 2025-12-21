using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Contracts.Commands;


public record class ProductCommand(
    [Required] Guid Id,
    [Required][StringLength(50)] string Name,
    [Required] Catagory Catagory,
    [Required] int CatagoryId,
    [Required] double Price,
    [Required] DateOnly ExpDate
) : IRequest<Product>;