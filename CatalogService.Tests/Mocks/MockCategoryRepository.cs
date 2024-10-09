using Application.Contracts.Persistence;
using CatalogService.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.UnitTests.Mocks
{
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetMockCategoryRepository()
        {
            var mockRepo = new Mock<ICategoryRepository>();
            List<Category> categories = [
                new Category(){ Id= 1, Name= "Electronics", ImageURL = "http://electronicsimg.com"},
                new Category(){ Id= 2, Name= "Laptops", ImageURL = "http://laptopsimg.com" , ParentCategoryId = 1, ParentCategory = new Category(){ Id= 1, Name= "Electronics", ImageURL = "http://electronicsimg.com"} },
            ];
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category.Id;
            });
            return mockRepo;
        }
    }
}
