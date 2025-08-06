using Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly DefaultContext _context;

  /// <summary>
  /// Initializes a new instance of ProductRepository
  /// </summary>
  /// <param name="context">The database context</param>
  public ProductRepository(DefaultContext context)
  {
    _context = context;
  }
  public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
  {
    await _context.Products.AddAsync(product, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
    return product;
  }

  public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
  {
    var product = await GetByIdAsync(id, cancellationToken);
    if (product is null)
      return false;

    _context.Products.Remove(product);
    await _context.SaveChangesAsync(cancellationToken);
    return true;
  }

  /// <summary>
  /// Retrieves a product by their unique identifier
  /// </summary>
  /// <param name="id">The unique identifier of the product</param>
  /// <param name="cancellationToken">Cancellation token</param>
  /// <returns>The cart if found, null otherwise</returns>
  public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    return await _context.Products
      .FirstOrDefaultAsync(product => product.Id == id, cancellationToken);
  }
}
