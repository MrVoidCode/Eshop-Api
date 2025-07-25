using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create;

internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
{
    private IDomainSellerRepository _repository;
    private IDomainSellerService service;

    public CreateSellerCommandHandler(IDomainSellerRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.UserId,request.ShopName, request.NationalCode, service);
        await _repository.AddAsync(seller);

        await _repository.Save();

        return OperationResult.Success();
    }
}