using FluentValidation;
using RecipeApiControllers.Models;

namespace RecipeApiControllers.Validators
{
    // RecipeValidator наслідує AbstractValidator<Recipe>
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            // Правило: Title не пустий, мінімум 5 символів
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Назва рецепту не може бути пустою.")
                .MinimumLength(5).WithMessage("Назва має містити щонайменше 5 символів.");

            // Правило з REGEX: Опис має починатися з великої літери (Вимога).
            RuleFor(x => x.Description)
                // Регулярний вираз: ^[A-ZА-ЯІЇЄ] означає "Починається з великої літери"
                .Matches(@"^[A-ZА-ЯІЇЄ].*") 
                .WithMessage("Опис має починатися з великої літери!");

            // Правило: DifficultyLevel має бути валідним значенням Enum.
            RuleFor(x => x.DifficultyLevel)
                .IsInEnum().WithMessage("Некоректний рівень складності.");
        }
    }
}