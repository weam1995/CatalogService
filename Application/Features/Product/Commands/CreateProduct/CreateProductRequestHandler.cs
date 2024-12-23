using AutoMapper;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<CreateProductRequest, int>
    {
        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = mapper.Map<CatalogService.Domain.Entities.Product>(request);
            await productRepository.CreateAsync(newProduct);
            return newProduct.Id;
        }
    }
}
