using Ambev.DeveloperEvaluation.Domain.Models.Products;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreateProductResult>();
    }
}