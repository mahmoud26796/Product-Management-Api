namespace ProductStore.Api.Contracts.Queries.CategoryQueries;

using MediatR;
using ProductStore.Api.Entities;

public record GetAllCategories() : IRequest<List<Category>>;