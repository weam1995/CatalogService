using Application.Contracts.Persistence;
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
        async Task IRequestHandler<DeleteCategoryRequest>.Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.CategoryId);
            await categoryRepository.DeleteAsync(category);
        }
    }
}
