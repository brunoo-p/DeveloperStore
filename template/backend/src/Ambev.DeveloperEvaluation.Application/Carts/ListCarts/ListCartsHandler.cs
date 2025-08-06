using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Handler for processing ListCartsCommand requests
/// </summary>
public class ListCartsHandler : IRequestHandler<ListCartsQuery, ListCartsResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListCartsHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ListCartsHandler(
        ICartRepository cartRepository,
        IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<ListCartsResult> Handle( ListCartsQuery request, CancellationToken cancellationToken )
    {
        var pagedCarts = await _cartRepository.GetPagedAsync(request.Page, request.PageSize, request.OrderBy, cancellationToken);
        return _mapper.Map<ListCartsResult>(pagedCarts);
    }
}
