using Application.Features.Category.Commands.DeleteCategory;
using FluentValidation;

namespace CatalogService.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryRequestValidation : AbstractValidator<DeleteCategoryRequest>
    {
        public DeleteCategoryRequestValidation()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }
    }
}
