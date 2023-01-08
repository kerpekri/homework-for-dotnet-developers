using System.ComponentModel.DataAnnotations;

namespace EG.Homework.Orders.Entities;

public class Order
{
    [Key]
    public long Id { get; set; }

    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
}