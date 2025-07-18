using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg;

public class Wallet :BaseEntity
{
    public Wallet(int price, WalletType type, string description, bool isFinally, DateTime finallyDate)
    {
        if (price < 500)
        {
            throw new InvalidDomainDataException("مبلغ وارد شده کمتر از حد مجاز است ");
        }

        Price = price;
        Type = type;
        Description = description;
        IsFinally = isFinally;
        FinallyDate = finallyDate;
    }
    public long UserId { get; internal set; }
    public int Price { get; set; }
    public WalletType Type { get; set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }

    public void Finally(string refCode)
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"کد پیگیری{refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }


}