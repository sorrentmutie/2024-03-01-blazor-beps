using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Interfaces;

namespace DemoBlazor.WASM.Services;

public class ServizioCategorieWASM : ICategorie
{
    public async  Task<List<Category>> EstraiCategorie()
    {
        await Task.Delay(1000);
        return new List<Category>();    
    }
}
