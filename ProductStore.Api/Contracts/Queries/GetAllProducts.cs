namespace ProductStore.Api.Contracts.Queries;

using MediatR;
using ProductStore.Api.Entities;

public record GetAllProducts() : IRequest<List<Product>>;