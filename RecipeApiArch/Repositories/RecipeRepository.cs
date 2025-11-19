using RecipeApi.Models;

namespace RecipeApi.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private static readonly List<Recipe> _recipes = new()
    {
        new Recipe { Id = 1, Title = "Борщ", Description = "Варити 2 години", Ingredients = "Буряк, м'ясо", Rating = 5.0 },
        new Recipe { Id = 2, Title = "Млинці", Description = "Смажити на сковороді", Ingredients = "Борошно, молоко", Rating = 4.8 }
    };

    public List<Recipe> GetAll() => _recipes;

    public Recipe? GetById(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public void Add(Recipe recipe)
    {
        recipe.Id = _recipes.Any() ? _recipes.Max(r => r.Id) + 1 : 1;
        _recipes.Add(recipe);
    }

    public void Update(Recipe recipe)
    {
        var index = _recipes.FindIndex(r => r.Id == recipe.Id);
        if (index != -1)
        {
            _recipes[index] = recipe;
        }
    }

    public void Delete(int id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        if (recipe != null)
        {
            _recipes.Remove(recipe);
        }
    }
}