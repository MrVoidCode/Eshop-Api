using Common.Application;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit;

internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerDomainRepository _repository;
    private readonly IDomainSellerService _service;

    public EditSellerCommandHandler(ISellerDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.UserId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.Edit(request.ShopName, request.NationalCode, _service);
        seller.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();
    }
}