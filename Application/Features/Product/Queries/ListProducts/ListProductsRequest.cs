using CatalogService.Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries.ListProducts
{
    public record ListProductsRequest : IRequest<List<ProductDto>>
    {
    }
}
