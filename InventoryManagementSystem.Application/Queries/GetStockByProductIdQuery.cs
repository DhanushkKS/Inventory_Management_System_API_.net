using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Queries;

public record GetStockByProductIdQuery(int ProductId):IRequest<Stock>;

public class GetStockByProductIdQueryHandler : IRequestHandler<GetStockByProductIdQuery, Stock>
{
    private readonly IStockRepository _stockRepository;

    public GetStockByProductIdQueryHandler(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public Task<Stock> Handle(GetStockByProductIdQuery request, CancellationToken cancellationToken)
    {
        var stock = _stockRepository.GetByProductId(request.ProductId);
        return Task.FromResult(stock);
    }
}
