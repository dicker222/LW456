using System.ComponentModel.DataAnnotations; 

namespace RecipeApiControllers.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Назва категорії обов'язкова!")] 
        [MinLength(3, ErrorMessage = "Мінімум 3 символи.")]
        public string Name { get; set; } = string.Empty;
    }
}