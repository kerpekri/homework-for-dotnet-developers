using EG.Homework.Orders.Entities;

namespace EG.Homework.Orders.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> Get(int customerId);
    Task Create(Order order);
}