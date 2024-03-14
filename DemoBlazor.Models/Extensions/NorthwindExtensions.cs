using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;

namespace DemoBlazor.Models.Extensions;

public static class NorthwindExtensions
{
    public static CategoryDTO ToDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.CategoryId,
            Name = category.CategoryName,
            Description = category.Description,
            Products = category.Products.Select(p => new ProductDTO
            {
                Id = p.ProductId,
                Name = p.ProductName,
            }).ToList()
        };
    }


    public static List<CategoryDTO> ToDTO
         (this List<Category> categories)
    {
        return categories.Select(c => new CategoryDTO
        {
            Id = c.CategoryId,
            Name = c.CategoryName,
            Description = c.Description,
            Products = c.Products.Select(p => new ProductDTO
            {
                Id = p.ProductId,
                Name = p.ProductName,
            }).ToList()
        }).ToList();
    }
}
