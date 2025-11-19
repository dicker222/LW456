using MongoDB.Driver;
using RecipeApi.Models;

namespace RecipeApi.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly IMongoCollection<Recipe> _collection;

    public RecipeRepository()
    {
        // Отримуємо колекцію "recipes"
        _collection = MongoDBClient.Instance.GetCollection<Recipe>("recipes");
    }

    public async Task<List<Recipe>> GetAllAsync() => 
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Recipe?> GetByIdAsync(string id) => 
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Recipe recipe) => 
        await _collection.InsertOneAsync(recipe);

    public async Task UpdateAsync(Recipe recipe) => 
        await _collection.ReplaceOneAsync(x => x.Id == recipe.Id, recipe);

    public async Task DeleteAsync(string id) => 
        await _collection.DeleteOneAsync(x => x.Id == id);
}