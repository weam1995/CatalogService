using Ardalis.GuardClauses;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;

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
