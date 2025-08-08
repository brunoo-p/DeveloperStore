using Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest {

    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public IEnumerable<SaleItemVo> Items { get; set; } = [];
}