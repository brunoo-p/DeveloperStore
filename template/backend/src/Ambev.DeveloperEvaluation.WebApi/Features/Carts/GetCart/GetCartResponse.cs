using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class GetCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<CartItemVo> Products { get; set; } = [];
}