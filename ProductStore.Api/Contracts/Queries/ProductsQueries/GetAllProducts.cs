namespace ProductStore.Api.Contracts.Queries.ProductsQueries;

using MediatR;
using ProductStore.Api.Entities;

public record GetAllProducts() : IRequest<List<Product>>;