using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using CatalogService.Domain.Models;
using CatalogService.Persistence.Contexts;

namespace CatalogService.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CatalogDBContext _dbContext;
        private readonly int _pageSize = 5;
        public ProductRepository(CatalogDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagedList<Product>> GetAllAsync(int categoryId, int pageIndex)
        {
            return PagedList<Product>.ToPagedList(_dbContext.Products.Where(x => x.CategoryId == categoryId).OrderBy(on => on.Name),
            pageIndex,
            _pageSize);
        }
    }
}
