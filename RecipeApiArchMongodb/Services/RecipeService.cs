using RecipeApi.Models;
using RecipeApi.Repositories;

namespace RecipeApi.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Recipe>> GetAllRecipesAsync() => await _repository.GetAllAsync();

    public async Task<Recipe?> GetRecipeByIdAsync(string id) => await _repository.GetByIdAsync(id);

    public async Task CreateRecipeAsync(Recipe recipe)
    {
        if (recipe.Rating < 0) recipe.Rating = 0;
        if (recipe.Rating > 5) recipe.Rating = 5;
        await _repository.CreateAsync(recipe);
    }

    public async Task<bool> UpdateRecipeAsync(string id, Recipe recipe)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;
        
        recipe.Id = id;
        await _repository.UpdateAsync(recipe);
        return true;
    }

    public async Task<bool> DeleteRecipeAsync(string id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;
        
        await _repository.DeleteAsync(id);
        return true;
    }
}