using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Common
{
    public class CategoryValidator: AbstractValidator<CatalogService.Domain.Entities.Category>
    {
        public void ApplyCommonValidations() {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Category name is required").MaximumLength(50).WithMessage("Category name cannot exceed 50 characters");
            RuleFor(x => x.ImageURL).Must(BeAValidUrl).When(x => !string.IsNullOrEmpty(x.ImageURL));
            RuleFor(x => x.ParentCategory.Id).GreaterThan(0).When(x => x.ParentCategory != null);
        }
        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
