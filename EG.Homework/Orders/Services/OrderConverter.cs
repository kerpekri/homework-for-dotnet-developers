using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Services;

public class OrderConverter : IOrderConverter
{
    public OrderModel ToModel(Order role) => new OrderModel();

    public Order ToEntity(CreateOrder order)
    {
        return new()
        {
            Amount = 1,
            CustomerId = 1,
            ExpectedDeliveryDate = DateTime.UtcNow// utc
        };
    }
}