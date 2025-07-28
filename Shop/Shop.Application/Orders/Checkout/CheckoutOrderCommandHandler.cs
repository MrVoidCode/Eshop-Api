using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.Checkout;

internal class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
{
    private readonly IOrderDomainRepository _repository;

    public CheckoutOrderCommandHandler(IOrderDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentOrderById(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.Checkout(new OrderAddress(request.Shire, request.City, request.PostalCode, request.Name, request.LastName,
            request.PostalCode, request.PhoneNumber, request.NationalCode));

        await _repository.Save();
        return OperationResult.Success();
    }
}