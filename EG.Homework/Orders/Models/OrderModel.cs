namespace EG.Homework.Orders.Models;

public class OrderModel
{
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
}