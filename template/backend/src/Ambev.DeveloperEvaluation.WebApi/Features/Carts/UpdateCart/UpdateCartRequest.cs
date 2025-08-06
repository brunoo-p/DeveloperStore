using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Represents a request to update a cart in the system.
/// </summary>
public class UpdateCartRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<CartItemVo> Products { get; set; } = [];
}