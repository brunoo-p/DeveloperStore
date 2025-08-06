using Ambev.DeveloperEvaluation.Application.Sales.Queries;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleFeatures.Queries.ListSale;

public sealed record ListSalesQuery : IRequest<IEnumerable<GetSaleResult>>;