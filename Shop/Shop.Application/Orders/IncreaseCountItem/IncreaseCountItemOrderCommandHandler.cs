using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseCountItem;

internal class IncreaseCountItemOrderCommandHandler : IBaseCommandHandler<IncreaseCountItemOrderCommand>
{
    private readonly IDomainOrderRepository _repository;

    public IncreaseCountItemOrderCommandHandler(IDomainOrderRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(IncreaseCountItemOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.GetCurrentOrderById(request.UserId);
        if (order == null)
        {
            return OperationResult.NotFound();
        }

        var item = order.Items.FirstOrDefault(c => c.InventoryId == request.ItemId);
        if (item == null)
        {
            return OperationResult.NotFound();
        }
        item.IncreaseCount(request.Count);
        await _repository.Save();
        return OperationResult.Success();
    }
}