using Application.Mapper;
using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Features.Product.Dtos
{
    public class ProductDto : IMapFrom<CatalogService.Domain.Entities.Product>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public Money Price { get; set; } = new Money(0, 0);
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Product, ProductDto>().ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
        }
    }
}
