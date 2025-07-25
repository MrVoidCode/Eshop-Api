using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    internal class AddImageProductCommand : IBaseCommand
    {
        public AddImageProductCommand(long productId, IFormFile imageName, int sequence)
        {
            ProductId = productId;
            Sequence = sequence;
            ImageName = imageName;
        }
        public long ProductId { get; private set; }
        public IFormFile ImageName { get; private set; }
        public int Sequence { get; private set; }
    }
}
