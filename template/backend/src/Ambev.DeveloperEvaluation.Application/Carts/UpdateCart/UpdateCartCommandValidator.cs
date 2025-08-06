using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for user creation command.
/// </summary>
public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Date: Must not be empty
    /// - Username: Required, must not be empty
    /// </remarks>
    public UpdateCartCommandValidator()
    {
        RuleFor(rule => rule.Date).NotEmpty().WithMessage("Date is required.");
        RuleFor(rule => rule.Products).NotEmpty().WithMessage("Products must be populated.");
    }
}