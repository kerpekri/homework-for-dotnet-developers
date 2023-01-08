namespace EG.Homework.Orders.Services;

public class LargeOrderDiscountStrategy : DiscountStrategy
{
    private new const decimal Discount = 0.15m;

    public override decimal ApplyDiscount(int quantity)
    {
        return BasePrice * (1 - Discount);
    }
}