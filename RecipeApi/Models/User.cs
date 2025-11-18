namespace RecipeApi.Models
{
    public class User // Клас, що описує користувача
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Для перевірки валідації
    }
}