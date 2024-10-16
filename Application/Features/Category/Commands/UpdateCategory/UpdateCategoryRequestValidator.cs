using Application.Features.Category.Commands.CreateCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Category name is required").MaximumLength(50).WithMessage("Category name cannot exceed 50 characters");
            RuleFor(x => x.ImageURL).Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.ImageURL));
        }
        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
