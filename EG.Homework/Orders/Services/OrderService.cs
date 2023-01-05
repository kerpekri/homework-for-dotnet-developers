using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;

namespace EG.Homework.Orders.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orders;
    private readonly IOrderConverter _converter;
    private readonly IDiscountStrategySelector _selector;

    public OrderService(IOrderRepository orders,
        IOrderConverter converter,
        IDiscountStrategySelector selector)
    {
        _orders = orders;
        _converter = converter;
        _selector = selector;
    }

    public async Task<OrderModel> Create(CreateOrder request)
    {
        var orderAmount = Convert.ToInt32(request.Amount);
        var discountStrategy = _selector.Select(orderAmount);

        var x = discountStrategy.ApplyDiscount(orderAmount);

        // apply discount

        var entity = _converter.ToEntity(request);
        await _orders.Create(entity);

        return new OrderModel();
    }
}