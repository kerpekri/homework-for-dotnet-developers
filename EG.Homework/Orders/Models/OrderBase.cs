namespace EG.Homework.Orders.Models;

public class OrderBase
{
    public double Amount { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
}