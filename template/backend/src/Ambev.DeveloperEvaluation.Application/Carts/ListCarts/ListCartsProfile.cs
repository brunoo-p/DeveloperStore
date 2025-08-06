using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Profile for mapping between Cart entity and ListCartsResult
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCarts operation
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<Domain.Entities.Cart, CartVo>();
        CreateMap<PaginatedListCart, ListCartsResult>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));
    }
}
