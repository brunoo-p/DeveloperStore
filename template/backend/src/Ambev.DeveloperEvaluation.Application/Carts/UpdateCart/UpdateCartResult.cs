using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;


/// <summary>
/// Represents the response returned after successfully update a cart.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the updated cart,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<CartItemVo> Products { get; set; } = [];
}