using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

/// <summary>
/// Represents a request to create a new user cart in the system
/// </summary>
public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public string Date { get; set; } = string.Empty;
    public List<CartItemVo> Products { get; set; } = [];
}
