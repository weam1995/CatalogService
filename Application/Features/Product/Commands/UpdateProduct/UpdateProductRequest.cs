using Application.Mapper;
using CatalogService.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public record UpdateProductRequest : IRequest, IMapFrom<CatalogService.Domain.Entities.Product>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public Money Price { get; set; }
        public int Amount { get; set; }
    }
}
