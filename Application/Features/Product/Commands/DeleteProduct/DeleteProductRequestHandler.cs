using Ardalis.GuardClauses;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductRequestHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductRequest>
    {
        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null) throw new NotFoundException(request.Id.ToString(), "Product");
            await productRepository.DeleteAsync(product);
        }
    }
}
