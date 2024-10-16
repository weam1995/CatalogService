using Application.Features.Category.Commands.CreateCategory;
using FluentValidation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.UnitTests.Features.Category.Validations
{
    public class CreateCategoryRequestValidatorTests
    {
        public readonly CreateCategoryRequestValidator _validator;
        public CreateCategoryRequestValidatorTests()
        {
            _validator = new CreateCategoryRequestValidator();

        }
        [Fact]
        public async Task CreateCategoryRequestValidation_EmptyCategoryName_ValidationShouldFail()
        {
            //Arrange
            var request = new CreateCategoryRequest(string.Empty, "https://gardening.com", 0);
            //Act
            var result = _validator.Validate(request);
            //Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeNull();
            result.Errors.Contains(new FluentValidation.Results.ValidationFailure() { PropertyName = "Name", ErrorMessage = "(\"Category name is required\"" });
        }

        [Fact]
        public async Task CreateCategoryRequestValidation_InvalidImageUrl_ValidationShouldFail()
        {
            //Arrange
            var request = new CreateCategoryRequest("Gardening", "Hello World", 0);
            //Act
            var result = _validator.Validate(request);
            //Assert
            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeNull();
            result.Errors.Contains(new FluentValidation.Results.ValidationFailure() { PropertyName = "ImageURL", ErrorMessage = "(\"ImageURL URL must be a valid URL\"" });
        }

        [Fact]
        public async Task CreateCategoryRequestValidation_EmptyImage_ValidationShouldSucceed()
        {
            //Arrange
            var request = new CreateCategoryRequest("Gardening", string.Empty, 0);
            //Act
            var result = _validator.Validate(request);
            //Assert
            result.IsValid.ShouldBeTrue();
        }
    }
}
