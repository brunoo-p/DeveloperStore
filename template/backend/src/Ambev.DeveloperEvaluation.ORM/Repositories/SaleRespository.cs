using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
///     Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    ///     Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository( DefaultContext context )
    {
        _context = context;
    }

    /// <summary>
    ///     Creates a new sale in the database
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync( Sale sale, CancellationToken cancellationToken = default )
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    ///     Update a sale
    /// </summary>
    /// <param name="sale"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Sale> UpdateAsync( Sale sale, CancellationToken cancellationToken = default )
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    ///     Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Sale?> GetByIdAsync( Guid id, CancellationToken cancellationToken = default )
    {
        return await _context.Sales
            .Include(sale => sale.Items)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    ///     Retrieves a collecition of sale
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sales if found, empty otherwise</returns>
    public async Task<Sale[]?> GetAsync( CancellationToken cancellationToken = default )
    {
        var sales = await _context.Sales
            .Include(sale => sale.Items)
            .OrderBy(s => s.CreatedAt)
            .ToArrayAsync(cancellationToken);

        return sales;
    }

    /// <summary>
    ///     Retrieves a last sequence of sale number identifier
    /// </summary>
    /// <param name="branchId">The unique identifier of the branch</param>
    /// <param name="year">The current year </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<string?> GetLastSequenceAsync( Guid branchId, int year, CancellationToken cancellationToken = default )
    {
        return await _context.Sales
            .Where(sale => sale.BranchId == branchId && sale.CreatedAt.Year == year)
            .OrderByDescending(sale => sale.CreatedAt)
            .Select(sale => sale.SaleNumber)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    ///     Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync( Guid id, CancellationToken cancellationToken = default )
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if ( sale == null )
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
