using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
public class ListCartsQuery: IRequest<ListCartsResult>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy {  get; set; }
}
