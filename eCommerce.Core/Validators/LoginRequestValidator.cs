

using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        // Email
        RuleFor(temp => temp.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email address format");

        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password can not be blank!");
    }
}
