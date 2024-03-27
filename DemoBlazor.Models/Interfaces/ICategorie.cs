using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;

namespace DemoBlazor.Models.Interfaces;

public interface ICategorie
{
    Task<List<Category>> EstraiCategorie();
    Task<List<CategoryDTO>?> EstraiCategorieDTOAsync();
    Task CreaCategoriaAsync(CategoryCreateDTO categoria);
    Task AggiornaCategoriaAsync(CategoryCreateDTO categoria);
}
