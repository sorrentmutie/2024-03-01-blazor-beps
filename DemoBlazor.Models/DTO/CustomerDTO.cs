using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.DTO;

public class CustomerDTO
{
    [Required(ErrorMessage = "Id obbligatorio")]
    [StringLength(5, MinimumLength = 5, ErrorMessage = "Length must be 5")]
    public string? Id { get; set; } 
    public string? CompanyName { get; set; }
    public string? ContactName { get; set; }

}
