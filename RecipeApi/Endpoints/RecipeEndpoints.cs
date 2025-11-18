using RecipeApi.Models; 
namespace RecipeApi.Endpoints
{
    public static class RecipeEndpoints
    {
        private static List<Recipe> recipes = new List<Recipe>()
        {
            new Recipe { Id = 1, Title = "Борщ", Description = "Класичний", CategoryId = 1, UserId = 1 },
            new Recipe { Id = 2, Title = "Салат Цезар", Description = "Легкий салат", CategoryId = 3, UserId = 1 }
        };

        private static bool IsTitleValid(string title)
        {
            return !string.IsNullOrWhiteSpace(title) && title.Length > 3;
        }
        public static void MapRecipeEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/recipes");

            group.MapGet("/", () => 
            {
                return Results.Ok(recipes); 
            });
            group.MapGet("/{id:int}", (int id) =>
            {
                var recipe = recipes.FirstOrDefault(r => r.Id == id);
                return recipe is not null ? Results.Ok(recipe) : Results.NotFound(); 
            });
            group.MapPost("/", (Recipe newRecipe) =>
            {
                if (!IsTitleValid(newRecipe.Title))
                {
                    return Results.BadRequest("Назва має бути довшою за 3 символи.");
                }
                newRecipe.Id = recipes.Any() ? recipes.Max(r => r.Id) + 1 : 1;
                recipes.Add(newRecipe);
                return Results.Created($"/recipes/{newRecipe.Id}", newRecipe); 
            });

            group.MapPut("/{id:int}", (int id, Recipe updatedRecipe) =>
            {
                var existingRecipe = recipes.FirstOrDefault(r => r.Id == id);
                if (existingRecipe is null) return Results.NotFound(); 

                existingRecipe.Title = updatedRecipe.Title;
                existingRecipe.Description = updatedRecipe.Description;
                existingRecipe.CategoryId = updatedRecipe.CategoryId;

                return Results.Ok(existingRecipe); 
            });

            group.MapDelete("/{id:int}", (int id) =>
            {
                var recipe = recipes.FirstOrDefault(r => r.Id == id);
                if (recipe is null) return Results.NotFound(); 

                recipes.Remove(recipe);
                return Results.NoContent(); 
            });
        }
    }
}