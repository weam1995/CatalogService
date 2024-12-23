using CatalogService.Domain.ValueObjects;

namespace KafkaDemo.Events
{
    public class ProductChangedEvent
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public Money Price { get; set; }
    }
}
