using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.System;

namespace EG.Homework.Orders.Services;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(
        DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> Get(int customerId)
    {
        var orders = _context.Orders.Where(ord => ord.CustomerId == customerId);

        if (orders is null) throw new KeyNotFoundException("Order not found");

        return orders;
    }

    public async Task Create(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}