using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// API response model for CreateCart operation
/// </summary>
public class CreateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Date {  get; set; } = string.Empty;
    public List<CartItemVo> Products { get; set; } = [];
}