using CatalogService.Domain.Entities.Common;

namespace CatalogService.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public List<Product> Products { get; set; } = [];

        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; } = 0;
        public List<Category> SubCategories { get; set; } = [];


    }
}
