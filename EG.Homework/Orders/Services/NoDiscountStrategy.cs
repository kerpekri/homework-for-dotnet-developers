namespace EG.Homework.Orders.Services;

public class NoDiscountStrategy : DiscountStrategy
{
    public override decimal ApplyDiscount(int quantity)
    {
        return BasePrice;
    }
}