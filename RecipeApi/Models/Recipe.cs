namespace RecipeApi.Models // Простір імен для Models
{
    public class Recipe // Клас, що описує один рецепт
    {
        public int Id { get; set; } // Унікальний ідентифікатор
        public string Title { get; set; } = string.Empty; // Назва рецепту
        public string Description { get; set; } = string.Empty; // Детальний опис
        public int CategoryId { get; set; } // Для зв'язку з Category
        public int UserId { get; set; } // Для зв'язку з User (автор)
    }
}