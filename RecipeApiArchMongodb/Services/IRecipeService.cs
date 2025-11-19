using RecipeApi.Models;

namespace RecipeApi.Services;

public interface IRecipeService
{
    Task<List<Recipe>> GetAllRecipesAsync();
    Task<Recipe?> GetRecipeByIdAsync(string id);
    Task CreateRecipeAsync(Recipe recipe);
    Task<bool> UpdateRecipeAsync(string id, Recipe recipe);
    Task<bool> DeleteRecipeAsync(string id);
}