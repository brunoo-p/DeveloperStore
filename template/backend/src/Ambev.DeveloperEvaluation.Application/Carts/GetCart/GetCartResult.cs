
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Response model for GetCart operation
/// </summary>
public class GetCartResult
{
    /// <summary>
    /// The unique identifier of the cart
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The cart's user ID
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// The created cart's date
    /// </summary>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// The cart's products reference
    /// </summary>
    public List<CartItemVo> Products { get; set; } = [];   
}
