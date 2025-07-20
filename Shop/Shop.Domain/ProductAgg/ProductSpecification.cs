using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.ProductAgg
{
    internal class ProductSpecification : BaseEntity
    {
        public ProductSpecification(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public long ProductId { get; internal set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
