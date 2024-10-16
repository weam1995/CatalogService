using CatalogService.Domain.Entities;
using CatalogService.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Common
{
    public class ProductValidator : AbstractValidator<CatalogService.Domain.Entities.Product>
    {
        public void ApplyCommonValidations() {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Product name is required").MaximumLength(50).WithMessage("Product name cannot exceed 50 characters");
            RuleFor(x => x.ImageURL).Must(BeAValidUrl).WithMessage("ImageURL URL must be a valid URL").When(x => !string.IsNullOrEmpty(x.ImageURL));
            RuleFor(x => x.Price).NotNull().WithMessage("Price is required");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.Price.Currency).IsInEnum();
        }
        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
