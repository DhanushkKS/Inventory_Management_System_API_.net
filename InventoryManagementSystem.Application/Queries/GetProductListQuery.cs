using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Queries;

public record GetProductListQuery():IRequest<List<Product>>;

public class GerProductListQueryHandler : IRequestHandler<GetProductListQuery,List< Product>>
{
    private readonly IProductRepository _productRepository;

    public GerProductListQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = _productRepository.GetAllProducts();
        return Task.FromResult(products);
    }
}