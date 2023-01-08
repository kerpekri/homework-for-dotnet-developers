using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orders;
    private readonly IOrderConverter _converter;
    private readonly IDiscountSelector _selector;

    public OrderService(IOrderRepository orders,
        IOrderConverter converter,
        IDiscountSelector selector)
    {
        _orders = orders;
        _converter = converter;
        _selector = selector;
    }

    public List<Order> Get(int customerId)
    {
        return _orders.Get(customerId).ToList();
    }

    public async Task<OrderModel> Create(CreateOrder request)
    {
        var orderAmount = ConvertToInt(request.Amount);
        var discountStrategy = _selector.Select(orderAmount);

        var price = discountStrategy.ApplyDiscount(orderAmount);

        var entity = _converter.ToEntity(request, price);
        await _orders.Create(entity);

        return _converter.ToModel(entity);
    }

    private static int ConvertToInt(decimal amount) => Convert.ToInt32(amount);
}