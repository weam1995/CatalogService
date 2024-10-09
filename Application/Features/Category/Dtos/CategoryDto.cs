using Application.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Features.Category.Dtos
{
    public class CategoryDto : IMapFrom<Domain.Entities.Category>
    {
        public string Name { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public string? ParentCategoryName{ get; set; }

        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<Domain.Entities.Category, CategoryDto>().ForMember(d => d.ParentCategoryName, opt => opt.MapFrom(src => src.ParentCategoryId != 0 ? src.ParentCategory.Name : string.Empty));
        }
    }
}
