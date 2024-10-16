using Application.Contracts.Persistence;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.UpdateCategory;
using AutoMapper;
using CatalogService.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CatalogService.Application.UnitTests.Features.Category.Commands
{
    public class UpdateCategoryRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public UpdateCategoryRequestHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetMockCategoryRepository();
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task UpdateCategory_ShouldIncrementCategoryItemsCount()
        {
            //Arrange
            var handler = new UpdateCategoryRequestHandler(_mockRepo.Object);
            //Act
            var request = new UpdateCategoryRequest() { Id = 3, Name = "Reserved Jackets", ImageURL = "http://Jacketsimg.com"};
            await handler.Handle(request , CancellationToken.None);
            
            _mockRepo.Verify(x=>x.UpdateAsync(It.Is<Domain.Entities.Category>(c=>c.Name.Equals("Reserved Jackets"))), Times.Once());    
            //var category = await _mockRepo.Object.GetByIdAsync(request.Id);

            ////Assert
            //category.ShouldNotBeNull();
            //category.Name.ShouldBe(request.Name);
        }
    }
}
