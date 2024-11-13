using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Configurations
{
    public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {       
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()"); ;
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ProcessedAt).HasColumnType("datetime2");
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
