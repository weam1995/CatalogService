using Application.Contracts.Persistence;
using MediatR;
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
            var product = await productRepository.GetByIdAsync(request.ProductId);
            await productRepository.DeleteAsync(product);
        }
    }
}
