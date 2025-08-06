using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Profile for mapping between cart entity and UpdateCartResponse
/// </summary>
public class UpdateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCart operation
    /// </summary>
    public UpdateCartProfile()
    {
        CreateMap<CartItemVo, CartItem>();
        CreateMap<UpdateCartCommand, Domain.Entities.Cart>()
        .ForMember(dest => dest.Date, opt =>
            opt.MapFrom(src => DateTime.SpecifyKind(DateTime.Parse(src.Date), DateTimeKind.Utc)));
        CreateMap<Domain.Entities.Cart, UpdateCartResult>();
    }
}
