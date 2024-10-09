using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Entities.Common;

namespace CatalogService.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public List<Product> Products { get; set; } = [];

        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Category> SubCategories { get; set; } = [];


    }
}
