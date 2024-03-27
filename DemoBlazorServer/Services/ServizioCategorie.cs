using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using DemoBlazor.Models.Extensions;

namespace DemoBlazorServer.Services;

public class ServizioCategorie : ICategorie
{
    private readonly NorthwindContext context;

    public ServizioCategorie(NorthwindContext context)
    {
        this.context = context;
    }

    public Task AggiornaCategoriaAsync(CategoryCreateDTO categoria)
    {
        throw new NotImplementedException();
    }

    public async Task CreaCategoriaAsync(CategoryCreateDTO categoria)
    {
        await context.Categories.AddAsync(new Category
        {
            CategoryName = categoria.Name,
            Description = categoria.Description
        });
        await context.SaveChangesAsync();
    }

    public async Task<List<Category>> EstraiCategorie()
    {
        return await context.Categories.Include(c => c.Products).ToListAsync();
    }

    public async Task<List<CategoryDTO>?> EstraiCategorieDTOAsync()
    {
        var categories =  await context.Categories.Include(c => c.Products).ToListAsync();
        return categories.ToDTO();
    }
}
