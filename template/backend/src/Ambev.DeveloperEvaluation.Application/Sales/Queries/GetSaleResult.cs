
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries;

public sealed record GetSaleResult(
    Guid Id,
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<SaleItemVo> Items);