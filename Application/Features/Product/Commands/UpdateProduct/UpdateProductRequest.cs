using Application.Mapper;
using AutoMapper;
using CatalogService.Domain.ValueObjects;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public record UpdateProductRequest : IRequest, IMapFrom<CatalogService.Domain.Entities.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public Money Price { get; set; } = new Money(0, 0);
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CatalogService.Domain.Entities.Product, UpdateProductRequest>().ReverseMap();
        }
    }
}
