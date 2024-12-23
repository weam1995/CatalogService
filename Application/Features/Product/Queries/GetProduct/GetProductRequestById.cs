using CatalogService.Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries.GetProduct
{
    public record GetProductRequestById : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public GetProductRequestById(int id)
        {
            Id = id;
        }
    }
}
