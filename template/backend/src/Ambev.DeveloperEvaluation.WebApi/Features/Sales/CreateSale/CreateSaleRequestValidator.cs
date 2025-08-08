using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.CustomerId).NotEmpty().NotNull();
        RuleFor(sale => sale.BranchId).NotEmpty().NotNull();
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Items cannot be empty")
            .Must(items => items != null && items.Any()).WithMessage("Sale must contain at least one item");
    }
}