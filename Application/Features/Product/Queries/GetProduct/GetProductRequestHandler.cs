using AutoMapper;
using CatalogService.Application.Features.Product.Dtos;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetProduct
{
    public class GetProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductRequestById, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductRequestById request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            return mapper.Map<ProductDto>(product);
        }
    }
}
