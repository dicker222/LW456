using FluentValidation;
using RecipeApiControllers.Models;

namespace RecipeApiControllers.Validators
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Назва рецепту не може бути пустою.")
                .MinimumLength(5).WithMessage("Назва має містити щонайменше 5 символів.");
            RuleFor(x => x.Description)
                .Matches(@"^[A-ZА-ЯІЇЄ].*") 
                .WithMessage("Опис має починатися з великої літери!");
            RuleFor(x => x.DifficultyLevel)
                .IsInEnum().WithMessage("Некоректний рівень складності.");
        }
    }
}