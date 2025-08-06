using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation.Cart.CartItem;

public class CartItemValidator : AbstractValidator<Entities.Carts.CartItem>
{
    public CartItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Product ID is required");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero");

        //RuleFor(x => x.UnitPrice)
        //    .GreaterThan(0).WithMessage("Unit price must be greater than zero");
    }
}
