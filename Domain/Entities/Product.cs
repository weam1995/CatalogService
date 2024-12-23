﻿using CatalogService.Domain.Entities.Common;
using CatalogService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Money Price { get; set; }
        public int Amount { get; set; }
    }
}
