using EG.Homework.Orders.Interfaces;

namespace EG.Homework.Orders.Services;

public class DiscountSelector : IDiscountSelector
{
    private const int TenItems = 10;
    private const int FortyNineItems = 49;
    private const int FiftyItems = 50;
    private const int NinetyNineItems = 999;

    public DiscountStrategy Select(int amount) =>
        amount switch
        {
            >= TenItems and <= FortyNineItems => new MediumOrderDiscountStrategy(),
            >= FiftyItems and <= NinetyNineItems => new LargeOrderDiscountStrategy(),
            _ => new SmallOrderDiscountStrategy()
        };
}