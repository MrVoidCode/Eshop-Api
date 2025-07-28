using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.DecreaseCount;

internal class DecreaseCountOrderCommandHandler : IBaseCommandHandler<DecreaseCountOrderCommand>
{
    private readonly IOrderDomainRepository _repository;

    public DecreaseCountOrderCommandHandler(IOrderDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(DecreaseCountOrderCommand request, CancellationToken cancellationToken)
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
        item.DecreaseCount(request.Count);
        await _repository.Save();
        return OperationResult.Success();
    }
}