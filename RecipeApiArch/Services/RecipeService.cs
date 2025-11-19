using RecipeApi.Models;
using RecipeApi.Repositories;

namespace RecipeApi.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    // Dependency Injection: Сервіс отримує Репозиторій
    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public List<Recipe> GetAllRecipes()
    {
        return _repository.GetAll();
    }

    public Recipe? GetRecipeById(int id)
    {
        return _repository.GetById(id);
    }

    public void CreateRecipe(Recipe recipe)
    {
        // Проста бізнес-логіка: рейтинг не може бути більше 5 або менше 0
        if (recipe.Rating < 0) recipe.Rating = 0;
        if (recipe.Rating > 5) recipe.Rating = 5;

        _repository.Add(recipe);
    }

    public bool UpdateRecipe(int id, Recipe recipe)
    {
        var existingRecipe = _repository.GetById(id);
        if (existingRecipe == null) return false; // Рецепт не знайдено

        recipe.Id = id; // ID змінювати не можна
        _repository.Update(recipe);
        return true;
    }

    public bool DeleteRecipe(int id)
    {
        var existingRecipe = _repository.GetById(id);
        if (existingRecipe == null) return false;

        _repository.Delete(id);
        return true;
    }
}