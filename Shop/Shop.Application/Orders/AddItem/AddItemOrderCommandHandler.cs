using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem;

public class AddItemOrderCommandHandler : IBaseCommandHandler<AddItemOrderCommand>
{
    private readonly IDomainOrderRepository _orderRepository;
    private readonly IDomainSellerRepository _sellerRepository;
    public async Task<OperationResult> Handle(AddItemOrderCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
        {
            return OperationResult.NotFound();
        }

        if (request.Count > inventory.Count)
        {
            return OperationResult.Error("تعداد محصول درخواستی بیشتر از موجودی است");
        }

        var order = await _orderRepository.GetCurrentOrderById(request.UserId);
        if (order == null)
        {
            order = new Order(request.UserId);
        }
        order.AddItem(new OrderItem(request.InventoryId, request.Price, request.Count));
        if (ItemCountGreaterThanInventoryCount(inventory, order))
        {
            return OperationResult.Error("تعداد محصول درخواستی بیشتر از موجودی است");
        }
        return OperationResult.Success();
    }

    public bool ItemCountGreaterThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.FirstOrDefault(c => c.InventoryId == inventory.InventoryId);
        if (orderItem.Count > inventory.Count)
        {
            return true;
        }
        return false;
    }
}