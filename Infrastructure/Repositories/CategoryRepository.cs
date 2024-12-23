using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using CatalogService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Persistence.Repositories
{
    public class CategoryRepository(CatalogDBContext dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
    {
        private readonly CatalogDBContext _dbContext = dbContext;

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.Include(x => x.ParentCategory).ToListAsync();
        }
        public override async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.ParentCategory).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
