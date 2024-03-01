using DemoBlazor.Models.Entities;

namespace DemoBlazor.Models.Interfaces;

public interface ICategorie
{
    Task<List<Category>> EstraiCategorie();
}
