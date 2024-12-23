using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using CatalogService.Domain.ValueObjects;
using AutoMapper;

namespace Application.Features.Product.Commands.CreateProduct
{
    public record CreateProductRequest : IRequest<int>, IMapFrom<CatalogService.Domain.Entities.Product>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public int CategoryId{ get; set; }
        public Money Price { get; set; } = new Money(0,0);
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CatalogService.Domain.Entities.Product, CreateProductRequest>().ReverseMap();
        }
    }
}
