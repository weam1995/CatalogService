
using Application.Features.Category.Commands.CreateCategory;
using AutoMapper;
using CatalogService.Application.UnitTests.Mocks;
using CatalogService.Domain.Interfaces.Persistence;
using Moq;
using Shouldly;

namespace CatalogService.UnitTests.Features.Category.Commands
{
    public class CreateCategoryRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public CreateCategoryRequestHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task CreateCategory_ShouldIncrementCategoryItemsCount()
        {
            //Arrange
            var handler = new CreateCategoryRequestHandler(_mockRepo.Object);
            //Act
            var result = await handler.Handle(new CreateCategoryRequest("Gardening", "https://gardening.com/", 0), CancellationToken.None);
            //Assert
            result.ShouldBe(5);
        }
    }
}
