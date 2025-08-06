using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateCartProfile()
    {
        CreateMap<CartItemVo, CartItem>();
        CreateMap<CreateCartCommand, Domain.Entities.Cart>()
        .ForMember(dest => dest.Date, opt =>
            opt.MapFrom(src => DateTime.SpecifyKind(DateTime.Parse(src.Date), DateTimeKind.Utc)));
        CreateMap<Domain.Entities.Cart, CreateCartResult>();
    }
}
