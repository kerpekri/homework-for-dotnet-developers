namespace EG.Homework.Orders.Services;

public class SmallOrderDiscountStrategy : DiscountStrategy
{
    public override decimal ApplyDiscount(int quantity)
    {
        return BasePrice;
    }
}