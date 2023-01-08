using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;
using EG.Homework.Orders.Services;
using Moq;

namespace EG.Homework.Tests.Orders.Services;

public class OrderServiceTests
{
    private readonly OrderService _service;

    private readonly Mock<IOrderRepository> _repo = new();
    private readonly Mock<IOrderConverter> _converter = new();
    private readonly Mock<IDiscountSelector> _selector = new();

    public OrderServiceTests()
    {
        _service = new OrderService(_repo.Object, _converter.Object, _selector.Object);
    }

    [Fact]
    public async Task Create_MustReturnCustomer_WhenExistingPartnerIdIsPassed()
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

        var result = await _service.Create(request);

        // result.CustomerName.Should().Be(customer.CustomerName);
        //
        // _unitOfWork.Verify(rep => rep.ScimCustomers.GetItemAsync(It.IsAny<long>()), Times.Once);
        // _scimUser.Verify(ser => ser.GetUser(It.IsAny<string>()), Times.Once);
    }
}