using Microsoft.AspNetCore.Mvc;
using RecipeApiControllers.Models;

namespace RecipeApiControllers.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] // Маршрут: /api/recipe
    public class RecipeController : ControllerBase
    {
        private static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe { Id = 1, Title = "Борщ", DifficultyLevel = Difficulty.Medium },
        };

        // 🟢 GET: /api/recipe
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_recipes);
        }

        // 🟠 POST: /api/recipe (Валідація FluentValidation + Regex)
        [HttpPost]
        public IActionResult Create(Recipe newRecipe)
        {
            // ВАЖЛИВО: Валідація (включаючи Regex) спрацьовує автоматично 
            // завдяки реєстрації FluentValidation в Program.cs.
            // Ми не пишемо тут жодного "if".

            newRecipe.Id = _recipes.Count > 0 ? _recipes.Max(r => r.Id) + 1 : 1;
            _recipes.Add(newRecipe);

            return CreatedAtAction(nameof(GetById), new { id = newRecipe.Id }, newRecipe);
        }
        
        // ... Повний CRUD для Recipe за аналогією з CategoryController ...

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            return recipe == null ? NotFound() : Ok(recipe);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Recipe updatedRecipe)
        {
            var existingRecipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (existingRecipe == null) return NotFound();

            existingRecipe.Title = updatedRecipe.Title;
            existingRecipe.Description = updatedRecipe.Description;
            existingRecipe.DifficultyLevel = updatedRecipe.DifficultyLevel;

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null) return NotFound();

            _recipes.Remove(recipe);
            return NoContent();
        }
    }
}