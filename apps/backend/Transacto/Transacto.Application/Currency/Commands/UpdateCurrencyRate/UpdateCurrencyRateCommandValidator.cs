/*
 * \file UpdateCurrencyRateCommandValidator.cs
 * \brief Validator class for the UpdateCurrencyRateCommand
 *
 * \date 18-09-2025
 */

using FluentValidation;

namespace Transacto.Application.Currency.Commands.UpdateCurrencyRate;

public class UpdateCurrencyRateCommandValidator : AbstractValidator<UpdateCurrencyRateCommand>
{
    public UpdateCurrencyRateCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required")
            .Length(3).WithMessage("Code must be exactly 3 characters long");
    }
}