namespace EG.Homework.Orders.Models;

public class OrderBase
{
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
}