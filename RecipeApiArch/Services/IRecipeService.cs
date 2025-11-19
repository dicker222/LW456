using RecipeApi.Models;

namespace RecipeApi.Services;

public interface IRecipeService
{
    List<Recipe> GetAllRecipes();
    Recipe? GetRecipeById(int id);
    void CreateRecipe(Recipe recipe);
    bool UpdateRecipe(int id, Recipe recipe);
    bool DeleteRecipe(int id);
}