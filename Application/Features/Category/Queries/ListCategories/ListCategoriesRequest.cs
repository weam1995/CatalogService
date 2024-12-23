using CatalogService.Application.Features.Category.Dtos;
using MediatR;

namespace Application.Features.Category.Queries.ListCategories
{
    public record ListCategoriesRequest : IRequest<List<CategoryDto>>
    {
    }
}
