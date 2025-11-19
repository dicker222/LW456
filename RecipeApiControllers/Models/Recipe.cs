namespace RecipeApiControllers.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        
        // Поле типу Enum
        public Difficulty DifficultyLevel { get; set; } 
    }
}