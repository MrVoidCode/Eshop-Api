using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.DeleteInventory;

internal class DeleteInventorySellerCommandHandler : IBaseCommandHandler<DeleteInventorySellerCommand>
{
    private readonly IDomainSellerRepository _repository;

    public DeleteInventorySellerCommandHandler(IDomainSellerRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(DeleteInventorySellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.DeleteInventory(request.ProductId);
        await _repository.Save();

        return OperationResult.Success();
    }
}