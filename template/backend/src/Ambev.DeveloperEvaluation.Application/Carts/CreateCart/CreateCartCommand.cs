using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a user, 
/// including username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateUserCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateCartCommand : IRequest<CreateCartResult>
{

    /// <summary>
    /// Gets or sets the UserId of the cart to be created.
    /// </summary>
    public Guid UserId { get; set; }


    /// <summary>
    /// Gets or sets the Date of the cart to be created.
    /// </summary>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Products of the cart to be created.
    /// </summary>
    public List<CartItemVo> Products { get; set; } = [];

}
