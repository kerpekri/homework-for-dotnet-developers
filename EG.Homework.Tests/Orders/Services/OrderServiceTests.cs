using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;
using EG.Homework.Orders.Services;
using FluentAssertions;
using Moq;

namespace EG.Homework.Tests.Orders.Services;

public class OrderServiceTests
{
    private const decimal SmallOrderBasePrice = 98.99m;
    private const decimal MediumOrderBasePrice = 94.0405m;
    private const decimal LargeOrderBasePrice = 84.1415m;

    private readonly OrderService _service;

    private readonly Mock<IOrderRepository> _repo = new();
    private readonly Mock<IOrderConverter> _converter = new();
    private readonly Mock<IDiscountSelector> _selector = new();

    public OrderServiceTests()
    {
        _service = new OrderService(_repo.Object, _converter.Object, _selector.Object);
    }

    [Fact]
    public async Task Create_MustReturnSmallOrderBasePrice_WhenOrderIsTwoKits()
    {
        CreateOrder request = new()
        {
            Amount = 2,
            CustomerId = 1,
            ExpectedDeliveryDate = DateTime.Now + TimeSpan.FromDays(1)
        };

        _selector
            .Setup(sel => sel.Select(It.IsAny<int>()))
            .Returns(new SmallOrderDiscountStrategy());

        Order order = new()
        {
            Amount = request.Amount,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()))
            .Returns(order);

        OrderModel response = new()
        {
            Amount = request.Amount,
            Price = SmallOrderBasePrice,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToModel(It.IsAny<Order>()))
            .Returns(response);

        var result = await _service.Create(request);

        result.Price.Should().Be(SmallOrderBasePrice);

        _converter.Verify(ser => ser.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()), Times.Once);
        _converter.Verify(ser => ser.ToModel(It.IsAny<Order>()), Times.Once);
        _selector.Verify(ser => ser.Select(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task Create_MustReturnMediumOrderBasePrice_WhenOrderIsTwoKits()
    {
        CreateOrder request = new()
        {
            Amount = 27,
            CustomerId = 1,
            ExpectedDeliveryDate = DateTime.Now + TimeSpan.FromDays(1)
        };

        _selector
            .Setup(sel => sel.Select(It.IsAny<int>()))
            .Returns(new MediumOrderDiscountStrategy());

        Order order = new()
        {
            Amount = request.Amount,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()))
            .Returns(order);

        OrderModel response = new()
        {
            Amount = request.Amount,
            Price = MediumOrderBasePrice,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToModel(It.IsAny<Order>()))
            .Returns(response);

        var result = await _service.Create(request);

        result.Price.Should().Be(MediumOrderBasePrice);

        _converter.Verify(ser => ser.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()), Times.Once);
        _converter.Verify(ser => ser.ToModel(It.IsAny<Order>()), Times.Once);
        _selector.Verify(ser => ser.Select(It.IsAny<int>()), Times.Once);
    }
    
    [Fact]
    public async Task Create_MustReturnLargeOrderBasePrice_WhenOrderIsTwoKits()
    {
        CreateOrder request = new()
        {
            Amount = 27,
            CustomerId = 1,
            ExpectedDeliveryDate = DateTime.Now + TimeSpan.FromDays(1)
        };

        _selector
            .Setup(sel => sel.Select(It.IsAny<int>()))
            .Returns(new MediumOrderDiscountStrategy());

        Order order = new()
        {
            Amount = request.Amount,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()))
            .Returns(order);

        OrderModel response = new()
        {
            Amount = request.Amount,
            Price = LargeOrderBasePrice,
            CustomerId = request.CustomerId,
            ExpectedDeliveryDate = request.ExpectedDeliveryDate
        };

        _converter
            .Setup(con => con.ToModel(It.IsAny<Order>()))
            .Returns(response);

        var result = await _service.Create(request);

        result.Price.Should().Be(LargeOrderBasePrice);

        _converter.Verify(ser => ser.ToEntity(It.IsAny<CreateOrder>(), It.IsAny<decimal>()), Times.Once);
        _converter.Verify(ser => ser.ToModel(It.IsAny<Order>()), Times.Once);
        _selector.Verify(ser => ser.Select(It.IsAny<int>()), Times.Once);
    }
}