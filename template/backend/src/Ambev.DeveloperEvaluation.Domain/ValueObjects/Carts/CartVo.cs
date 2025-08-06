namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

public class CartVo
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<CartItemVo> Products { get; set; } = [];

    private readonly List<CartItemVo> _products = [];
}
