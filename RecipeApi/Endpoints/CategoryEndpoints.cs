using RecipeApi.Models;

namespace RecipeApi.Endpoints
{
    public static class CategoryEndpoints
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Супи" },
            new Category { Id = 2, Name = "Десерти" },
            new Category { Id = 3, Name = "Салати" }
        };

        public static void MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/categories");

            group.MapGet("/", () => Results.Ok(categories));

            group.MapGet("/{id:int}", (int id) =>
            {
                var category = categories.FirstOrDefault(c => c.Id == id);
                return category is not null ? Results.Ok(category) : Results.NotFound();
            });

            // POST (з валідацією)
            group.MapPost("/", (Category category) =>
            {
                if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length < 3)
                {
                    return Results.BadRequest("Назва категорії має бути не менше 3 символів."); 
                }
                
                category.Id = categories.Any() ? categories.Max(c => c.Id) + 1 : 1;
                categories.Add(category);
                
                return Results.Created($"/categories/{category.Id}", category); 
            });

            // PUT
            group.MapPut("/{id:int}", (int id, Category updatedCategory) =>
            {
                var existingCategory = categories.FirstOrDefault(c => c.Id == id);
                if (existingCategory is null) return Results.NotFound();

                existingCategory.Name = updatedCategory.Name;

                return Results.Ok(existingCategory); 
            });
            
            // DELETE
            group.MapDelete("/{id:int}", (int id) =>
            {
                var category = categories.FirstOrDefault(c => c.Id == id);
                if (category is null) return Results.NotFound();

                categories.Remove(category);
                return Results.NoContent(); 
            });
        }
    }
}