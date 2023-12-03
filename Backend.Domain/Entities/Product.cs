﻿namespace Backend.Domain.Entities;

public class Product(string name, decimal price) : BaseEntity
{
    public string Name { get; private set; } = name;
    public decimal Price { get; private set; } = price;

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;

        base.Update();
    }
}