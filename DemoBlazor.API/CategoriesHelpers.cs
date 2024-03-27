using DemoBlazor.Models.Entities;
using Microsoft.EntityFrameworkCore;
using DemoBlazor.Models.Extensions;
using DemoBlazor.Models.DTO;

namespace DemoBlazor.API;

public static class CategoriesHelpers
{
    public static async Task<IResult>
        GetCategories(NorthwindContext database)
    {
        var categories = await database.Categories
        .Include(c => c.Products)
        .ToListAsync();
        return Results.Ok(categories.ToDTO());
    }

    public static async Task<IResult>
        GetById(NorthwindContext database, int id)
    {
        var category = await database.Categories
                 .Include(c => c.Products)
                 .FirstOrDefaultAsync(c => c.CategoryId == id);
        if (category == null)
        {
            return Results.NotFound();
        }
        else
        {
            return Results.Ok(category.ToDTO());
        }
    }


    public static async Task<IResult>
        CreateCategory(NorthwindContext database, CategoryCreateDTO newCategory)
    {
        var category = new Category
        {
            CategoryName = newCategory.Name,
            Description = newCategory.Description
        };
        await database.Categories.AddAsync(category);
        await database.SaveChangesAsync();
        return TypedResults.Created($"/categories/{category.CategoryId}",
            category.ToDTO());
    }

    public static async Task<IResult> DeleteCategory(NorthwindContext database, int id)
    {
        var category = await database.Categories
        .FindAsync(id);
        if (category == null)
        {
            return Results.NotFound();
        }
        else
        {
            database.Categories.Remove(category);
            await database.SaveChangesAsync();
            return Results.NoContent();
        }
    }

    public async static Task<IResult> UpdateCategory(NorthwindContext database,
        CategoryCreateDTO category, int id)
    {
        var categoryToUpdate = await database.Categories.FindAsync(id);
        if (categoryToUpdate == null)
        {
            return Results.NotFound();
        }
        else
        {
            categoryToUpdate.CategoryName = category.Name;
            categoryToUpdate.Description = category.Description;
            await database.SaveChangesAsync();
            return Results.NoContent();
        }
    }

    public async static Task<IResult> PatchCategory(NorthwindContext database,
        CategoryCreateDTO category, int id)
    {
        var categoryToUpdate = await database.Categories.FindAsync(id);
        if (categoryToUpdate == null)
        {
            return Results.NotFound();
        }
        else
        {
            if (category.Name != null)
                categoryToUpdate.CategoryName = category.Name;

            if (category.Name != null)
                categoryToUpdate.Description = category.Description;

            await database.SaveChangesAsync();
            return Results.NoContent();
        }
    }

}
