namespace ProductStore.Api.Contracts.Commands.Products;

using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductStore.Api.Entities;



public record UpdateProductCommand(
    [Required][StringLength(50)] string Name,
    [Required] Category Category,
    [Required] int CategoryId,
    [Required] double Price,
    [Required] DateOnly ExpDate
);

/*
    in the Update Product we used a bit different approach so we can pass the correct id from the dbContext
    that matches the id in the route url so the id is authoritative — we don’t rely on the client to send it in the body.
    also we do not need it in the update command record it self since that's no going to ba changed (the Id)
*/
public record UpdateProductCommandId(Guid Id, UpdateProductCommand Data) : IRequest;