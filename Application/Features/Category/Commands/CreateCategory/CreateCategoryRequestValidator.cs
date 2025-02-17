﻿
using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Category name is required").MaximumLength(50).WithMessage("Category name cannot exceed 50 characters");
            RuleFor(x => x.ImageURL).Must(BeAValidUrl!).When(x => !string.IsNullOrEmpty(x.ImageURL));
        }
        private static bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
