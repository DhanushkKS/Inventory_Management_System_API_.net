using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Queries;

public record GetStockListQuery():IRequest<List<Stock>>;

public class GerStockListQueryHandler : IRequestHandler<GetStockListQuery,List< Stock>>
{
    private readonly IStockRepository _stockRepository;

    public GerStockListQueryHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public Task<List<Stock>> Handle(GetStockListQuery request, CancellationToken cancellationToken)
    {
        List<Stock> stocks = _stockRepository.GetAll();
        return Task.FromResult(stocks);
    }
}