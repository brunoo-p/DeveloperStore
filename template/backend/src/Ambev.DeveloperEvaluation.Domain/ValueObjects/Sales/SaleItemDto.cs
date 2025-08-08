namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

public sealed record SaleItemVo(
    Guid ProductId,
    decimal UnitPrice,
    int Quantity);