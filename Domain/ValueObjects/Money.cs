using CatalogService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; set; }
        public CurrencyCode Currency { get; set; }
    }
}
