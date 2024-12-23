

using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Product name is required").MaximumLength(50).WithMessage("Product name cannot exceed 50 characters");
            RuleFor(x => x.ImageURL).Must(BeAValidUrl!).WithMessage("ImageURL URL must be a valid URL").When(x => !string.IsNullOrEmpty(x.ImageURL));
            RuleFor(x => x.Price).NotNull().WithMessage("Price is required");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.Price.Currency).IsInEnum();
        }
        private static bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
