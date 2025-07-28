using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.RemoveItem;

internal class RemoveItemOrderCommandHandler : IBaseCommandHandler<RemoveItemOrderCommand>
{
    private readonly IOrderDomainRepository _repository;

    public RemoveItemOrderCommandHandler(IOrderDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(RemoveItemOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentOrderById(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }
        order.RemoveItem(request.ItemId);
        await _repository.Save();
        return OperationResult.Success();
    }
}