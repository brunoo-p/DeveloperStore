using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
///  Represents a cart in the system with products and information about.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<CartItem> Products { get; set; } = [];

    private readonly List<CartItem> _products = [];


    public void AddProduct( CartItem cartProduct, int quantity )
    {
        var existing = _products.FirstOrDefault(i => i.ProductId == cartProduct.Id);
        if ( existing != null )
        {
            var totalQuantity = existing.Quantity + quantity;
            if ( totalQuantity > 20 )
                throw new DomainException("Maximum 20 items.");

            existing.Increase(quantity);
        }
        else
        {
            _products.Add(cartProduct);
        }
    }

    public void RemoveProduct( Guid productId )
    {
        var item = _products.FirstOrDefault(i => i.ProductId == productId);
        if ( item != null ) _products.Remove(item);
    }

    //public List<SaleItem> ToSaleItems()
    //{
    //    return _products.Select(i => new SaleItem(i.Product, i.Quantity)).ToList();
    //}
}