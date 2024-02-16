using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Queries;

public record GetSaleListQuery():IRequest<List<Sale>>;

public class GerSaleListQueryHandler : IRequestHandler<GetSaleListQuery,List< Sale>>
{
    private readonly ISaleRepository _saleRepository;

    public GerSaleListQueryHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public Task<List<Sale>> Handle(GetSaleListQuery request, CancellationToken cancellationToken)
    {
        List<Sale> sales = _saleRepository.GetAll();
        return Task.FromResult(sales);
    }
}