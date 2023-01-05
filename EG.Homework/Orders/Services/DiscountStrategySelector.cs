using EG.Homework.Orders.Interfaces;

namespace EG.Homework.Orders.Services;

public class DiscountStrategySelector : IDiscountStrategySelector
{
    private const int FromTenItems = 10;
    private const int FromFiftyItems = 50;

    public DiscountStrategy Select(int amount) =>
        amount switch
        {
            >= FromTenItems and <= 49 => new DiscountTwoStrategy(),
            >= FromFiftyItems and <= 999 => new DiscountThreeStrategy(),
            _ => new NoDiscountStrategy()
        };
}