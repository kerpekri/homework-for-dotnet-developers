using EG.Homework.Orders.Entities;
using EG.Homework.Orders.Models;
using EG.Homework.Orders.Services;

namespace EG.Homework.Orders.Interfaces;

public interface IOrderConverter
{
    Order ToEntity(CreateOrder order);
    OrderModel ToModel(Order role);
}