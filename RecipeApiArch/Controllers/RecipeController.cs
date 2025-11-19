using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;
using RecipeApi.Services;

namespace RecipeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _service;

    public RecipeController(IRecipeService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
        return Ok(_service.GetAllRecipes());
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
        var recipe = _service.GetRecipeById(id);
        if (recipe == null) return NotFound("Рецепт не знайдено");
        return Ok(recipe);
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
        if (string.IsNullOrWhiteSpace(recipe.Title))
            return BadRequest("Назва рецепту обов'язкова");

        _service.CreateRecipe(recipe);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Recipe recipe)
    {
        var result = _service.UpdateRecipe(id, recipe);
        if (!result) return NotFound();
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _service.DeleteRecipe(id);
        if (!result) return NotFound();
        return NoContent();
    }
}