using Ambev.DeveloperEvaluation.Domain.Models.Products;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products;

public class CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = mapper.Map<Product>(command);

        var createdProduct = await productRepository.CreateAsync(product, cancellationToken);
        var result = mapper.Map<CreateProductResult>(createdProduct);
        return result;
    }
}