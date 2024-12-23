﻿using Application.Mapper;
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

        public override bool Equals(object obj)
        {
            if (obj is CategoryDto other)
            {
                return this.Name == other.Name &&
                       this.ImageURL == other.ImageURL;
            }
            return false;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>().ForMember(d => d.ParentCategoryName, opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : string.Empty));
        }
    }
}
