using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Command for update a cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a cart, 
/// including userId, date, products. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateCartResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateCartCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateCartCommand : IRequest<UpdateCartResult>
{

    /// <summary>
    /// Gets or sets the Id of the cart to be created.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the userId of the cart to be created.
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// Gets or sets the Date of the cart to be created.
    /// </summary>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Product of the cart to be created.
    /// </summary>
    public List<CartItemVo> Products { get; set; } = [];

}
