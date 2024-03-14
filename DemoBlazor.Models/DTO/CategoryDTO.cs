﻿namespace DemoBlazor.Models.DTO;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ProductDTO> Products { get; set; } = new();
}

public class CategoryCreateDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
