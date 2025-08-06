namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

public sealed record SaleVo(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<SaleItemVo>? Items)
{
    public SaleVo() : this(Guid.Empty, string.Empty, 0, default, Guid.Empty, Guid.Empty, default, default, default)
    {
    }
}