using AutoMapper;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<CreateProductRequest, int>
    {
        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = mapper.Map<CatalogService.Domain.Entities.Product>(request);
            return await productRepository.CreateAsync(newProduct);
        }
    }
}
