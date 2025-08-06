using Ambev.DeveloperEvaluation.Domain.Validation.Cart.CartItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Validator for CreateCartRequest that defines validation rules for cart creation.
/// </summary>
public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - userId: Must be valid
    /// - Products: Required, not maximum
    /// - Date: Must have a date when cart was created)
    /// </remarks>
    public CreateCartRequestValidator()
    {
        RuleFor(cart => cart.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");
        RuleFor(cart => cart.Date)
            .NotEmpty()
            .Must(date => DateTime.TryParse(date, out _))
            .WithMessage("Invalid Date.");
        RuleForEach(cart => cart.Products).ChildRules(product =>
        {
            product.RuleFor(p => p.ProductId).NotEmpty();
            product.RuleFor(p => p.Quantity).InclusiveBetween(1, 20)
                .WithMessage("Quantity must be between 1 and 20 un.");
        });
    }
}
