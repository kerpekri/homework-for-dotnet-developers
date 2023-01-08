using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EG.Homework.Orders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orders;
    private readonly IValidator<CreateOrder> _validator;

    public OrdersController(IOrderService orders,
        IValidator<CreateOrder> validator)
    {
        _orders = orders;
        _validator = validator;
    }

    [HttpGet]
    public IActionResult Get(int customerId)
    {
        return Ok(_orders.Get(customerId));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrder request)
    {
        await _validator.ValidateAndThrowAsync(request);

        return Ok(await _orders.Create(request));
    }
}