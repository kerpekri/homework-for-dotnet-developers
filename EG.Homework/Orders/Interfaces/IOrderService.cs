using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Interfaces;

public interface IOrderService
{
    Task<OrderModel> Create(CreateOrder request);
}