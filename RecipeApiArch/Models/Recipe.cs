namespace RecipeApi.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; // Назва страви
    public string Description { get; set; } = string.Empty; // Опис приготування
    public string Ingredients { get; set; } = string.Empty; // Інгредієнти
    public double Rating { get; set; } // Рейтинг (0-5)
}