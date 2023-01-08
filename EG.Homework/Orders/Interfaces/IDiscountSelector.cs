using EG.Homework.Orders.Services;

namespace EG.Homework.Orders.Interfaces;

public interface IDiscountSelector
{
    DiscountStrategy Select(int amount);
}