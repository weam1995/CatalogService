using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using CatalogService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Repositories
{
    public class OutboxMessageRepository(CatalogDBContext dbContext) : IOutboxMessageRepository
    {
        public async Task<Guid> CreateAsync(OutboxMessage message)
        {
            await dbContext.OutboxMessages.AddAsync(message);
            await dbContext.SaveChangesAsync();
            return message.Id;
        }
    }
}
