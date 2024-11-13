using Application.Features.Product.Commands.DeleteProduct;
using Ardalis.GuardClauses;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryRequest>
    {
        public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if (category is null) throw new NotFoundException(request.Id.ToString(), "Category");
            await categoryRepository.DeleteAsync(category);
        }
    }
}
