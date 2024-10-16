using Ardalis.GuardClauses;
using CatalogService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; set; }
        public CurrencyCode Currency { get; set; }

        public Money(decimal value, CurrencyCode currency)
        {
            Value = Guard.Against.NegativeOrZero(value);
            Currency = Guard.Against.EnumOutOfRange(currency);
        }
    }
}
