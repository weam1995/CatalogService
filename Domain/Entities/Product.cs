using CatalogService.Domain.Entities.Common;
using CatalogService.Domain.ValueObjects;

namespace CatalogService.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public Money? Price { get; set; }
        public int Amount { get; set; }
    }
}
