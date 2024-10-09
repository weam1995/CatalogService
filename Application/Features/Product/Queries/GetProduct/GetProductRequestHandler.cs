using Application.Contracts.Persistence;
using AutoMapper;
using CatalogService.Application.Features.Product.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetProduct
{
    public class GetProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductRequest, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);
            return mapper.Map<ProductDto>(product);
        }
    }
}
