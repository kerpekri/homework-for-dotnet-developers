using EG.Homework.Orders.Entities;
using Microsoft.EntityFrameworkCore;

namespace EG.Homework.System;

public class ApiContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "OrderDatabase");
    }

    public DbSet<Order> Orders { get; set; }
}