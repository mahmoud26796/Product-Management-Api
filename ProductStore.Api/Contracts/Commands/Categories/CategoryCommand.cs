using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Contracts.Commands.Categories;


public record class CreateCategoryCommand(
    [Required] int Id,
    [Required][StringLength(50)] string Name
) : IRequest<Category>;