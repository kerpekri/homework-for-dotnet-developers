using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Services;

public class OrderConverter : IOrderConverter
{
    public OrderModel ToModel(Order order) => new()
    {
        Amount = order.Amount,
        Price = order.Price,
        ExpectedDeliveryDate = order.ExpectedDeliveryDate,
        CustomerId = order.CustomerId
    };

    public Order ToEntity(CreateOrder order, decimal price)
    {
        return new()
        {
            Price = price,
            Amount = order.Amount,
            CustomerId = order.CustomerId,
            ExpectedDeliveryDate = DateTime.SpecifyKind(order.ExpectedDeliveryDate, DateTimeKind.Utc)
        };
    }
}