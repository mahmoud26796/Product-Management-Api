using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Contracts.Commands;


public record class CategoryCommand(
    [Required] Guid Id,
    [Required][StringLength(50)] string Name
) : IRequest<Category>;