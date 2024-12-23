
using Application.Features.Category.Queries.ListCategories;
using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Application.UnitTests.Mocks;
using CatalogService.Domain.Interfaces.Persistence;
using Moq;
using Shouldly;

namespace CatalogService.Application.UnitTests.Features.Category.Queries
{
    public class ListCategoriesRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public ListCategoriesRequestHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task ListCategoriesTest_ShouldReturnCorrectCategoriesCount()
        {
            //Arrange
            var handler = new ListCategoriesRequestHandler(_mockRepo.Object, _mapper);
            //Act
            var result = await handler.Handle(new ListCategoriesRequest(), CancellationToken.None);
            //Assert
            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(5);
        }
    }
}
