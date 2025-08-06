using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
public class PaginatedListCart
{
    public List<Cart> Data { get; private set; } = [];
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int PageNumber{ get; private set; }

    public async Task<PaginatedListCart> CreateAsync( IQueryable<Cart> source, int pageNumber, int pageSize )
    {
        Data = await source.Skip(( pageNumber - 1 ) * pageSize).Take(pageSize).ToListAsync();
        PageSize = pageSize;
        TotalPages = await source.CountAsync();
        PageNumber = pageNumber;
        return this;
    }
}
