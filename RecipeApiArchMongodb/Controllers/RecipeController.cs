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
    public async Task<ActionResult<List<Recipe>>> GetAll()
    {
        return Ok(await _service.GetAllRecipesAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetById(string id)
    {
        var recipe = await _service.GetRecipeByIdAsync(id);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Recipe recipe)
    {
        await _service.CreateRecipeAsync(recipe);
        return Ok(recipe);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, Recipe recipe)
    {
        var result = await _service.UpdateRecipeAsync(id, recipe);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var result = await _service.DeleteRecipeAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}