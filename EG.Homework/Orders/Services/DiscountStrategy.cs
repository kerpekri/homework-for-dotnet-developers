namespace EG.Homework.Orders.Services;

public abstract class DiscountStrategy
{
    protected const decimal BasePrice = 98.99m;
    protected const decimal Discount = 0m;
    
    public abstract decimal ApplyDiscount(int quantity);
}