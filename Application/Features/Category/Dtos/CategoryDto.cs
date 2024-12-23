using Application.Mapper;
using AutoMapper;

namespace CatalogService.Application.Features.Category.Dtos
{
    public sealed class CategoryDto : IMapFrom<Domain.Entities.Category>, IEquatable<CategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public string? ParentCategoryName { get; set; }

        public bool Equals(CategoryDto? other)
        {
            return other != null && this.Name == other.Name &&
                     this.ImageURL == other.ImageURL;
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Category, CategoryDto>().ForMember(d => d.ParentCategoryName, opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Name : string.Empty));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CategoryDto);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
