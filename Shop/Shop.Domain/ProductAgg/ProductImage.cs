using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(string imageName, int sequence)
        {
            Sequence = sequence;
            ImageName = imageName;
        }
        public long ProductId { get; private set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }
    }
}
