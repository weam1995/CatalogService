using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.ListCategories;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Controllers;
using CatalogService.Domain.Entities;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.DataCollection;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.UnitTests.Controller
{
    public class CategoriesControllerTests
    {
        private readonly Mock<ISender> _sender;
        private readonly CategoriesController _categoriesController;
        public CategoriesControllerTests() { 
            _sender = new Mock<ISender>();
            _categoriesController = new CategoriesController(_sender.Object);
        }

        [Fact]
        public async Task GetCategories_ReturnOk()
        {
            //Arrange
            List<CategoryDto> categories = [];
            _sender.Setup(m => m.Send(It.IsAny<ListCategoriesRequest>(), default)).ReturnsAsync(categories);
            //Act
            var result = await _categoriesController.ListCategories();
            //Assert
            result.Should().NotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public async Task GetCategories_ShouldReturnListCategoryDto()
        {
            //Arrange
            List<CategoryDto> categories = [];
            categories.Add(new CategoryDto() { Name = "Electronics", ImageURL = "http://www.electronics.com" });
            _sender.Setup(m => m.Send(new ListCategoriesRequest(), default)).ReturnsAsync(categories);
            //Act
            var result = await _categoriesController.ListCategories();
            //Assert
            result.Should().NotBeNull();
            var okResult = result as OkObjectResult;
            okResult?.Value.ShouldBeOfType(typeof(List<CategoryDto>));
            var resultCategories = okResult?.Value as List<CategoryDto>;
            resultCategories?.Count.ShouldBeEquivalentTo(categories.Count);
        }
        [Fact]
        public async Task CreateCategory_ReturnOk()
        {
            //Arrange

            var request = new CreateCategoryRequest("Electronics", "http://www.electronics.com", 0);
            _sender.Setup(m => m.Send(request, default)).ReturnsAsync(1);
            //Act
            var result = await _categoriesController.Create(request);
            result.Should().NotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));

        }
        [Fact]
        public async Task CreateCategory_ShouldReturnCorrectId()
        {
            //Arrange

            var request = new CreateCategoryRequest("Electronics", "http://www.electronics.com", 0);
            _sender.Setup(m => m.Send(request, default)).ReturnsAsync(1);
            //Act
            var result = await _categoriesController.Create(request);
            result.Should().NotBeNull();
            result.ShouldBeOfType(typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            okResult?.Value.ShouldBeOfType(typeof(int));
            var resultValue = okResult?.Value;
            resultValue?.ShouldBeEquivalentTo(1);
        }
        [Fact]
        public async Task UpdateCategory_ShouldReturnOk()
        {
            //Arrange
            var request = new UpdateCategoryRequest() { Id = 1, Name = "Electronics-Updated", ImageURL = "http://www.electronics.com", ParentCategoryId = 0 };
            _sender.Setup(m => m.Send(It.IsAny<GetCategoryByIdRequest>(), default)).ReturnsAsync(new CategoryDto() { Name = "Electronics", ImageURL = request.ImageURL, ParentCategoryName = ""});
            //Act
            var result = await _categoriesController.Update(request);
            //Assert
            result.Should().NotBeNull();
            result.ShouldBeOfType(typeof(OkResult));
        }
        [Fact]
        public async Task UpdateCategory_ShouldReturnNotFound()
        {
            //Arrange
            var request = new UpdateCategoryRequest() { Id = 1, Name = "Electronics-Updated", ImageURL = "http://www.electronics.com", ParentCategoryId = 0 };
            _sender.Setup(m => m.Send(It.IsAny<GetCategoryByIdRequest>(), default)).ReturnsAsync(new CategoryDto());
            //Act
            var result = await _categoriesController.Update(request);
            //Assert
            result.ShouldBeOfType(typeof(NotFoundResult));
        }
    }
}
