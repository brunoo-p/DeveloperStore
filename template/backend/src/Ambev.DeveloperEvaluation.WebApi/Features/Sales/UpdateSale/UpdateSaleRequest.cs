using Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public sealed record UpdateSaleRequest(
    string SaleNumber,
    decimal TotalAmount,
    bool IsCancelled,
    Guid? CustomerId,
    Guid? BranchId,
    IEnumerable<SaleItemVo> Items);