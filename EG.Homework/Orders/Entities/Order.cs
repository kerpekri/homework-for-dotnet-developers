using System.ComponentModel.DataAnnotations;

namespace EG.Homework.Orders.Entities;

public class Order
{
    [Key]
    public long Id { get; set; }

    public int Amount { get; set; }
    public int CustomerId { get; set; }
    public DateTime ExpectedDeliveryDate { get; set; }
}