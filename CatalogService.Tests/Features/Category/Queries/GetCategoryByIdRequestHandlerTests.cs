using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.ListCategories;
using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.UnitTests.Features.Category.Queries
{
    public class GetCategoryByIdRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public GetCategoryByIdRequestHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetCategoryById_ShouldContainData()
        {
            //Arrange
            var handler = new GetCategoryByIdRequestHandler(_mockRepo.Object, _mapper);
            //Act
            var result = await handler.Handle(new GetCategoryByIdRequest(1), CancellationToken.None);
            //Assert
            result.ShouldBeOfType<CategoryDto>();
            result.ShouldNotBeNull();
        }
        [Fact]
        public async Task GetCategoryById_ShouldReturnCorrectParentCategoryName()
        {
            //Arrange
            var handler = new GetCategoryByIdRequestHandler(_mockRepo.Object, _mapper);
            //Act
            var result = await handler.Handle(new GetCategoryByIdRequest(1), CancellationToken.None);

            //Assert
            result.ParentCategoryName.ShouldBeEquivalentTo("Electronics");
        }
    }
}
