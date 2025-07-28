using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInventory
{
    internal class EditInventorySellerCommand : IBaseCommand
    {
        public EditInventorySellerCommand(long userId, long inventoryId, int count, int price, int? discountPercentage)
        {
            UserId = userId;
            InventoryId = inventoryId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public long UserId { get; private set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }
    }
    internal class EditInventorySellerCommandHandler : IBaseCommandHandler<EditInventorySellerCommand>
    {
        private readonly ISellerDomainRepository _repository;

        public EditInventorySellerCommandHandler(ISellerDomainRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditInventorySellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _repository.GetTracking(request.UserId);
            if (seller == null)
            {
                return OperationResult.NotFound();
            }
            seller.EditInventory(request.InventoryId, request.Count, request.Price, request.DiscountPercentage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    internal class EditInventorySellerCommandValidation : AbstractValidator<EditInventorySellerCommand>
    {
    }
}
