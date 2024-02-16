using AutoMapper;
using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Dtos.StockDtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands;

public record CreateStockCommand(CreateStockDto Stock):IRequest<Stock>;

public class CreateStockCommandHandler:IRequestHandler<CreateStockCommand,Stock>
{
    private readonly IMapper _mapper;
    private readonly IStockRepository _stockRepository;
    
    public CreateStockCommandHandler(IMapper mapper, IStockRepository stockRepository)
    {
        _mapper = mapper;
        _stockRepository = stockRepository;
    }
    
    
    public Task<Stock> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
         
        var stock = _mapper.Map<Stock>(request.Stock);
        _stockRepository.Create(stock);
        return Task.FromResult(stock);
    }
}