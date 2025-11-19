using Microsoft.AspNetCore.Mvc;
using RecipeApiControllers.Models;
namespace RecipeApiControllers.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class RecipeController : ControllerBase
    {
        private static List<Recipe> _recipes = new List<Recipe>
        {
            new Recipe { Id = 1, Title = "Борщ", DifficultyLevel = Difficulty.Medium },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_recipes);
        }

        [HttpPost]
        public IActionResult Create(Recipe newRecipe)
        {
            newRecipe.Id = _recipes.Count > 0 ? _recipes.Max(r => r.Id) + 1 : 1;
            _recipes.Add(newRecipe);
            return CreatedAtAction(nameof(GetById), new { id = newRecipe.Id }, newRecipe);
        }
        

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