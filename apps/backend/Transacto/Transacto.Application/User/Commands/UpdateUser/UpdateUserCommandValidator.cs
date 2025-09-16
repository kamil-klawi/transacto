/*
 * \file UpdateUserCommandValidator.cs
 * \brief Validator class for the UpdateUserCommand
 *
 * \date 16-09-2025
 */

using FluentValidation;

namespace Transacto.Application.User.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.PasswordHash).NotEmpty().WithMessage("Password hash is required.");
    }
}