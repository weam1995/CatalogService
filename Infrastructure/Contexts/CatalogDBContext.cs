using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Contexts
{
    public class CatalogDBContext : DbContext , ICatalogDBContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options) {
        
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DatabaseFacade Database => base.Database;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
