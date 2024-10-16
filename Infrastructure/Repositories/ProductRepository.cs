using Application.Contracts.Persistence;
using CatalogService.Domain.Entities;
using CatalogService.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CatalogDBContext dbContext) : base(dbContext)
        {
        }
    }
}
