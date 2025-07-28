using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInventory;

internal class AddInventorySellerCommandHandle : IBaseCommandHandler<AddInventorySellerCommand>
{
    private readonly ISellerDomainRepository _repository;

    public AddInventorySellerCommandHandle(ISellerDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(AddInventorySellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.AddInventory(new SellerInventory(request.ProductId, request.Count, request.Price, request.DiscountPercentage));
        await _repository.Save();

        return OperationResult.Success();
    }
}