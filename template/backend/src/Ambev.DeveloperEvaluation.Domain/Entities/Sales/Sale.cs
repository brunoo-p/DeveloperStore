using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales;

public class Sale : BaseEntity
{
    public string SaleNumber { get; private set; } = string.Empty;
    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; private set; }
    public Guid? CustomerId { get; private set; }
    public Guid? BranchId { get; private set; }

    private readonly List<SaleItem> _items = [];
    public IReadOnlyCollection<SaleItem> Items => _items;

    public void Update(decimal totalAmount, bool isCancelled, Guid? customerId, Guid? branchId)
    {
        TotalAmount = totalAmount;
        IsCancelled = isCancelled;
        CustomerId = customerId;
        BranchId = branchId;
    }

    public void UpdateItems(SaleItem[] items)
    {
        _items.RemoveAll(x => items.All(item => item.ProductId != x.ProductId));

        foreach (var item in items)
        {
            var existingItem = _items.Find(item => item.ProductId == item.ProductId);

            if (existingItem is not null)
                existingItem.Update(item);
            else
                _items.Add(item);
        }

        Calculate();
        UpdateTimestamp();
    }

    public void Calculate()
    {
        CalculateTotalAmount();
        CalculateDiscount();
    }

    public void Cancel()
    {
        if (IsCancelled)
            throw new InvalidOperationException("Sale is already cancelled.");

        IsCancelled = true;
        UpdateTimestamp();
    }

    public void CancelItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item == null)
            throw new KeyNotFoundException($"Item with ID {itemId} not found.");

        _items.Remove(item);

        if (_items.Count == 0)
            Cancel();
        else
        {
            Calculate();
            UpdateTimestamp();
        }
    }

    public void UpdateTimestamp()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddItem(SaleItem item)
    {
        _items.Add(item);
    }
    
    private void CalculateTotalAmount()
    {
        TotalAmount = _items.Sum(item => item.Quantity);
    }

    private void CalculateDiscount()
    {
        foreach (var item in _items)
            item.CalculateDiscount();
    }

}
