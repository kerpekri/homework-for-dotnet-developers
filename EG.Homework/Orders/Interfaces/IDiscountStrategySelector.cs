using EG.Homework.Orders.Services;

namespace EG.Homework.Orders.Interfaces;

public interface IDiscountStrategySelector
{
    DiscountStrategy Select(int amount);
}