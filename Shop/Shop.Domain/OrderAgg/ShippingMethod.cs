using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class ShippingMethod : BaseValueObject
{
    public string ShippingTitle { get; private set; }
    public int ShippingCost { get; private set; }
}