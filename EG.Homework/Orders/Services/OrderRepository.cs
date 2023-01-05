using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.System;

namespace EG.Homework.Orders.Services;

public class OrderRepository : IOrderRepository
{
    public OrderRepository()
    {
        using var context = new ApiContext();
        var authors = new List<Order>
        {
            new Order()
            {
            },
            new Order()
            {
            }
        };

        context.Orders.AddRange(authors);
        context.SaveChanges();
    }

    public List<Order> Get()
    {
        using (var context = new ApiContext())
        {
            var list = context.Orders
                // .Include(a => a.Books)
                .ToList();
            return list;
        }
    }

    public async Task Create(Order order)
    {
        await using var databaseContext = new ApiContext();

        await databaseContext.Orders.AddAsync(order);
    }
}