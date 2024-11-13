using AutoMapper;
using CatalogService.Application.Features.Product.Dtos;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.ListProducts
{
    public class ListProductsRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<ListProductsRequest, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            return mapper.Map<List<ProductDto>>(products);
        }
    }
}
