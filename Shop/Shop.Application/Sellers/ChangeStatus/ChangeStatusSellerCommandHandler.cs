using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.ChangeStatus;

internal class ChangeStatusSellerCommandHandler : IBaseCommandHandler<ChangeStatusSellerCommand>
{
    private readonly ISellerDomainRepository _repository;

    public ChangeStatusSellerCommandHandler(ISellerDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(ChangeStatusSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();

    }
}