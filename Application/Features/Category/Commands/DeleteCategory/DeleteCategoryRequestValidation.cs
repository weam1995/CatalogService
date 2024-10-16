using Application.Features.Category.Commands.DeleteCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryRequestValidation : AbstractValidator<DeleteCategoryRequest>
    {
        public DeleteCategoryRequestValidation() {
            RuleFor(x => x.CategoryId).GreaterThanOrEqualTo(0);
        }
    }
}
