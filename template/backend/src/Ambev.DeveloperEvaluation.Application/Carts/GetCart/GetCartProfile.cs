using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetCartProfile()
    {
        CreateMap<Domain.Entities.Cart, GetCartResult>();
        CreateMap<CartItem, CartItemVo>();
    }
}
