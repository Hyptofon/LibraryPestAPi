using FluentValidation;

namespace Application.Authors.Commands;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ім'я обов'язкове")
            .MinimumLength(3).WithMessage("Ім'я має містити принаймні 3 символи");
    }
}