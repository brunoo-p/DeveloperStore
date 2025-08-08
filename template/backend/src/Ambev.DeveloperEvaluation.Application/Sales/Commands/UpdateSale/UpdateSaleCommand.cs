using Ambev.DeveloperEvaluation.Domain.ValueObjects.Sales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;

public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{

    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; } = decimal.Zero;
    public bool IsCancelled { get; set; } = false;
    public Guid CustomerId { get; set; }
    public Guid BranchId { get; set; }
    public IEnumerable<SaleItemVo> Items { get; set; } = [];
}