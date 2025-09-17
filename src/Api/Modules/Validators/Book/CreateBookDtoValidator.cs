using Api.Dtos;
using FluentValidation;

namespace Api.Modules.Validators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Назва книги обов'язкова")
            .MinimumLength(3).WithMessage("Назва книги має містити принаймні 3 символи");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Опис книги обов'язковий")
            .MinimumLength(3).WithMessage("Опис книги має містити принаймні 3 символи");
    }
}