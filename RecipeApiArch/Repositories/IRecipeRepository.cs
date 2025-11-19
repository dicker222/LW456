using RecipeApi.Models;

namespace RecipeApi.Repositories;

public interface IRecipeRepository
{
    List<Recipe> GetAll();
    Recipe? GetById(int id);
    void Add(Recipe recipe);
    void Update(Recipe recipe);
    void Delete(int id);
}