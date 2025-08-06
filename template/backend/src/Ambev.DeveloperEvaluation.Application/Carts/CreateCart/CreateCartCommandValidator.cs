using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartCommand that defines validation rules for user creation command.
/// </summary>
public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Date: Must not be empty
    /// - Username: Required, must not be empty
    /// </remarks>
    public CreateCartCommandValidator()
    {
        RuleFor(rule => rule.Date).NotEmpty();
        RuleFor(rule => rule.Products).NotEmpty();
    }
}