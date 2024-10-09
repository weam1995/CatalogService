﻿using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x => x.Price.Value).HasColumnName("Price").HasColumnType("decimal(18,2)");
            builder.Property(x => x.Price.Currency).HasColumnName("Currency").HasMaxLength(3);
        }
    }
}
