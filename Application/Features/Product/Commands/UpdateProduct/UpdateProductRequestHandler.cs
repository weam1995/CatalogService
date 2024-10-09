using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<UpdateProductRequest>
    {
        public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<CatalogService.Domain.Entities.Product>(request);
            await productRepository.UpdateAsync(product);
        }
    }
}
