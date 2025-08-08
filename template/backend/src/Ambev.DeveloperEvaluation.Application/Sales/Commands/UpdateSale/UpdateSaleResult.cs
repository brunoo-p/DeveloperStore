using Ambev.DeveloperEvaluation.Domain.Entities.Sales;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; } = false;
    public decimal TotalAmount { get; set; } = decimal.Zero;
    public IEnumerable<SaleItem> Items { get; set; } = [];
}
