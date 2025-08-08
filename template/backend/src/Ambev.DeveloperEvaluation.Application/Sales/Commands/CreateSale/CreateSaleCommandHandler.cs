using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;

public class CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        int saleNumberLasSequence = await GetNextSaleNumberSequenceAsync(
            command.BranchId,
            saleRepository
        );

        var sale = mapper.Map<Sale>(command);
        sale.GenerateSaleNumberSequence(saleNumberLasSequence);
        sale.Calculate();

        var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
        var result = mapper.Map<CreateSaleResult>(createdSale);

        return result;
    }

    private static async Task<int> GetNextSaleNumberSequenceAsync( Guid branchId, ISaleRepository saleRepository )
    {
        var lastSaleNumber = await saleRepository.GetLastSequenceAsync(branchId, DateTime.UtcNow.Year);
        if ( lastSaleNumber is null ) return 0;

        int lastNumber = ExtractNumber(lastSaleNumber);
        return ++lastNumber;
    }

    private static int ExtractNumber( string saleNumber )
    {
        var parts = saleNumber?.Split('-');
        if ( parts?.Length == 4 && int.TryParse(parts[3], out int number) )
            return number;
        return 0;
    }
}