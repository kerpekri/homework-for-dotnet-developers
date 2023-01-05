using EG.Homework.Orders.Entities;

namespace EG.Homework.Orders.Interfaces;

public interface IOrderRepository
{
    Task Create(Order order);
    // List<Order> GetAuthors();
}