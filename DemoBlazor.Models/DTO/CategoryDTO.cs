using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.DTO;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ProductDTO> Products { get; set; } = new();
}

public class CategoryCreateDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(15, ErrorMessage = "The Name field must have a maximum length of 15 characters.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "The Description field is required.")]
    public string? Description { get; set; }
}
