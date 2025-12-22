using MediatR;
using ProductStore.Api.Entities;

namespace ProductStore.Api.Contracts.Queries.ProductsQueries;

public record GetProductById(Guid Id) : IRequest<Product>;