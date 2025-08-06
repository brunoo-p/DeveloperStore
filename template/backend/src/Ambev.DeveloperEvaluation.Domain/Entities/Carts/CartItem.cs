using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Carts;
public class CartItem : BaseEntity
{
    private readonly int LIMIT = 20;
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public CartItem( Guid productId, int quantity )
    {
        CheckLimit(quantity);
        Quantity = quantity;
        ProductId = productId;
    }
    public void Increase(int value)
    {
        CheckLimit(value);
        Quantity += value;
    }

    private void CheckLimit(int value) {
        if ( Quantity + value > LIMIT )
            throw new DomainException($"You trying to add {Quantity + value} items. The limite is {LIMIT}.");
    }
}
