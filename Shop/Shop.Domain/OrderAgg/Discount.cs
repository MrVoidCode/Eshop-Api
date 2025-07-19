using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class Discount :BaseValueObject
    {
        public string Title{ get; private set; }
        public int Amount { get; private set; }
    }
}