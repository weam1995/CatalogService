using CatalogService.Application.Features.Product.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetProduct
{
    public record GetProductRequestById : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public GetProductRequestById(int id)
        {
            Id = id;
        }
    }
}
