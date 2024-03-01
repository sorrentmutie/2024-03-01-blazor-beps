using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServer.Services;

public class ServizioCategorie : ICategorie
{
    private readonly NorthwindContext context;

    public ServizioCategorie(NorthwindContext context)
    {
        this.context = context;
    }

    public async Task<List<Category>> EstraiCategorie()
    {
        return await context.Categories.Include(c => c.Products).ToListAsync();
    }
}
