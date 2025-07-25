using Common.Application;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.RemoveImage
{
    public class RemoveImageProductCommand : IBaseCommand
    {
        public RemoveImageProductCommand(long productId, long imageId)
        {
            ProductId = productId;
            ImageId = imageId;
        }
        public long ProductId { get; private set; }
        public long ImageId { get; private set; }
    }
}
