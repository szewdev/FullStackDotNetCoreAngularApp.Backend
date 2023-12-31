﻿namespace Backend.Application.DTOs;

public record ProductDto(int Id, string Name, decimal Price, string? Description, bool IsActive);