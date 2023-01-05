using System.Reflection;
using EG.Homework;
using EG.Homework.Orders.Interfaces;
using EG.Homework.Orders.Services;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderConverter, OrderConverter>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services
    .AddControllers()
    .AddFluentValidation(options => {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();