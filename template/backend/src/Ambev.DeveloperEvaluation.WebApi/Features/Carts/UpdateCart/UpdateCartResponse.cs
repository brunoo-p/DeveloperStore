using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// API response model for UpdateCart operation
/// </summary>
public class UpdateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public List<CartItemVo> Products { get; set; } = [];
}