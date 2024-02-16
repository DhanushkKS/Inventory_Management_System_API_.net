using AutoMapper;
using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Dtos.ProductDtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands;

public record CreateProductCommand(CreateProductDto Product):IRequest<Product>;

public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand,Product>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    
    public Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Product);
        _productRepository.CreateProduct(product);
        return Task.FromResult(product);
    }
}