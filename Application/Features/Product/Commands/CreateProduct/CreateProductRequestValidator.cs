using Application.Features.Product.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator() {
            new ProductValidator().ApplyCommonRules();
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Category Id is required").GreaterThan(0).WithMessage("Category Id is not Valid");

        }

    }
}
