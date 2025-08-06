using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.Carts;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects.Carts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : ICartRepository
{

    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart if found, null otherwise</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
        .Include(c => c.Products)
        .FirstOrDefaultAsync(cart => cart.Id == id, cancellationToken);
    }

    /// <summary>
    /// Paginate all carts
    /// </summary>
    /// <param name="page">The current page</param>
    /// <param name="pageSize">The count of pages</param>
    /// <param name="orderBy">The optional param to order response</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of carts if found, empty otherwise</returns>
    public async Task<PaginatedListCart> GetPagedAsync( int page, int pageSize, string? orderBy, CancellationToken cancellationToken = default )
    {
        var query = _context.Carts.Include(c => c.Products).AsQueryable();

        if ( !string.IsNullOrWhiteSpace(orderBy) )
        {
            query = query.OrderBy(orderBy, cancellationToken);
        }

        var paginatedList = new PaginatedListCart();
        var data = await paginatedList.CreateAsync(query, page, pageSize);
        return paginatedList;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart is null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Cart?> UpdateAsync(Guid id, Cart cart, CancellationToken cancellationToken = default)
    {
        var cartById = await GetByIdAsync(id, cancellationToken);
        if ( cartById is null )
            return null;

        cartById.Products.AddRange(cart.Products);
        var productDictionary = cart.Products
            .GroupBy(p => p.ProductId)
            .ToDictionary(
                g => g.Key,
                g => new CartItem(g.Key, g.Sum(p => p.Quantity))
            );

        cartById.Products = [.. productDictionary.Values];
        await _context.SaveChangesAsync(cancellationToken);
        return cartById;
    }
}
