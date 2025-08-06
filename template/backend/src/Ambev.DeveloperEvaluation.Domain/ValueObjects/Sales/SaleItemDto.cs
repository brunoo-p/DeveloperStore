namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

public sealed record SaleItemVo(
    Guid Id,
    int Quantity,
    decimal UnitPrice,
    decimal Discount,
    decimal TotalItemAmount,
    Guid ProductId)
{
    public SaleItemVo() : this(Guid.Empty, 0, 0, 0, 0, Guid.Empty)
    {
    }
}