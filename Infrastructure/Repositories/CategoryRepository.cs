using Application.Contracts.Persistence;
using CatalogService.Domain.Entities;
using CatalogService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly CatalogDBContext _dbContext;
        public CategoryRepository(CatalogDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.Include(x => x.ParentCategory).ToListAsync();
        }
        public override async Task<Category> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.Include(x=>x.ParentCategory).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
