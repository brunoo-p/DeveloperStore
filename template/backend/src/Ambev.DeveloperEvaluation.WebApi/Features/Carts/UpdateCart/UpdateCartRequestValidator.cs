using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartRequest that defines validation rules for cart update.
/// </summary>
public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - userId: Must be valid
    /// - Products: Required, not maximum
    /// - Date: Must have a date when cart was updated)
    /// </remarks>
    public UpdateCartRequestValidator()
    {
        RuleFor(cart => cart.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required.");
        RuleFor(cart => cart.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");
        RuleFor(cart => cart.Products)
            .NotEmpty()
            .WithMessage("Cart must be populated.");
        RuleFor(cart => cart.Date)
            .NotEmpty()
            .WithMessage("Date is required.");        
    }
}
