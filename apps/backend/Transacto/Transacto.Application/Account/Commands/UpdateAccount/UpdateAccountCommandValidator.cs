/*
 * \file UpdateAccountCommandValidator.cs
 * \brief Validator class for the UpdateAccountCommand
 *
 * \date 17-09-2025
 */

using FluentValidation;

namespace Transacto.Application.Account.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(3, 100)
            .WithMessage("Name must be between 3 and 100 characters");
        
        RuleFor(a => a.Type)
            .IsInEnum()
            .WithMessage("Invalid account type");
    }
}