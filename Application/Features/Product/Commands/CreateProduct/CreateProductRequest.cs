using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mapper;
using CatalogService.Domain.ValueObjects;

namespace Application.Features.Product.Commands.CreateProduct
{
    public record CreateProductRequest : IRequest<int>, IMapFrom<CatalogService.Domain.Entities.Product>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId{ get; set; }
        public Money Price { get; set; } = new Money();
        public int Amount { get; set; }
    }
}
