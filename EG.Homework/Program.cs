using System.Reflection;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Services;
using EG.Homework.System;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;

    services.AddDbContext<DataContext>();
    services.AddCors();

    services.AddScoped<IOrderService, OrderService>();
    services.AddScoped<IOrderConverter, OrderConverter>();
    services.AddScoped<IDiscountSelector, DiscountSelector>();
    services.AddScoped<IOrderRepository, OrderRepository>();
}

builder.Services
    .AddControllers()
    .AddFluentValidation(options => {
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();