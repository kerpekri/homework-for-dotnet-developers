using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Interfaces;

public interface IOrderService
{
    List<Order> Get(int customerId);
    Task<OrderModel> Create(CreateOrder request);
}