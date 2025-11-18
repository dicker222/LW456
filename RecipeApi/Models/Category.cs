namespace RecipeApi.Models
{
    public class Category // Клас, що описує категорію (Супи, Десерти)
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Назва категорії
    }
}