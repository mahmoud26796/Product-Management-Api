using MediatR;

namespace ProductStore.Api.Contracts.Commands.Products;

public record DeleteProductById(Guid Id) : IRequest;