using Microsoft.AspNetCore.Mvc;
using RecipeApiControllers.Models;

namespace RecipeApiControllers.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class CategoryController : ControllerBase 
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Супи" },
            new Category { Id = 2, Name = "Десерти" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categories); 
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            newCategory.Id = _categories.Count > 0 ? _categories.Max(c => c.Id) + 1 : 1;
            _categories.Add(newCategory);
            return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory); 
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return category == null ? NotFound() : Ok(category); 
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Category updatedCategory)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null) return NotFound();
            existingCategory.Name = updatedCategory.Name;
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            _categories.Remove(category);
            return NoContent();
        }
    }
}