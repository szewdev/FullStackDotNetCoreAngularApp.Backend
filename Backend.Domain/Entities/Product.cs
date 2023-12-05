﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Domain.Entities;

public class Product(string name, decimal price) : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name should contain at least two characters")]
    public string Name { get; private set; } = name;

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; private set; } = price;

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;

        base.Update();
    }
}