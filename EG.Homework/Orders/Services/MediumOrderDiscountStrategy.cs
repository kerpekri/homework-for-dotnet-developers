namespace EG.Homework.Orders.Services;

public class MediumOrderDiscountStrategy : DiscountStrategy
{
    private new const decimal Discount = 0.05m;

    public override decimal ApplyDiscount(int quantity)
    {
        return BasePrice * (1 - Discount);
    }
}