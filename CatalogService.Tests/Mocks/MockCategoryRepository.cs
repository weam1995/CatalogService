
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
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
                new Category(){ Id= 0, Name= "Electronics", ImageURL = "http://electronicsimg.com"},
                new Category(){ Id= 1, Name= "Laptops", ImageURL = "http://laptopsimg.com" , ParentCategoryId = 0},
                new Category(){ Id= 2, Name= "Clothing", ImageURL = "http://clothingimg.com" },
                new Category(){ Id= 3, Name= "Jackets", ImageURL = "http://Jacketsimg.com" , ParentCategoryId = 2 },
                new Category(){ Id= 4, Name= "Pants", ImageURL = "http://pantsimg.com" , ParentCategoryId = 2},
            ];
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => { 
                Category category = categories.First(x => x.Id == id);
                category.ParentCategory = categories.FirstOrDefault(x => x.Id == category.ParentCategoryId);
                return category;
            });
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                category.Id = categories.Count;
                categories.Add(category);
                return category.Id;
            });
            return mockRepo;
        }
    }
}
