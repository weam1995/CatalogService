using CatalogService.Domain.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryRequest, int>
    {
        public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new CatalogService.Domain.Entities.Category()
            {
                Name = request.Name ?? string.Empty,
                ImageURL = request.ImageURL,
                ParentCategoryId = request.ParentCategoryId
            };
            return await categoryRepository.CreateAsync(newCategory);
        }
    }
}
