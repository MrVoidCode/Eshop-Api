using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace Shop.Domain.ProductAgg
{
    internal class ProductImage : BaseEntity
    {
        public ProductImage(string title, string imageName)
        {
            Title = title;
            ImageName = imageName;
        }
        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
    }
}
