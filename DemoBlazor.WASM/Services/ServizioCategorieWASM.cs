using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Interfaces;
using System.Net.Http.Json;

namespace DemoBlazor.WASM.Services;

public class ServizioCategorieWASM : ICategorie
{
    private readonly HttpClient httpClient;

    public ServizioCategorieWASM(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task CreaCategoriaAsync(CategoryCreateDTO categoria)
    {
        await httpClient.PostAsJsonAsync(
            "https://localhost:7251/categories", categoria);
    }

    public async  Task<List<Category>> EstraiCategorie()
    {
        await Task.Delay(1000);
        return new List<Category>();    
    }

    public async Task<List<CategoryDTO>?> EstraiCategorieDTOAsync()
    {
        var responseMessage =  await httpClient.GetAsync("https://localhost:7251/categories");
        if(responseMessage.IsSuccessStatusCode)
        {
            var categories = await 
            responseMessage.Content
            .ReadFromJsonAsync<List<CategoryDTO>>();

            return categories;
        } else
        {
            throw new Exception("Servizio non raggiungibile");
        }
    }
}
