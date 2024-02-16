using AutoMapper;
using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Dtos.SaleDtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands;

public record CreateSaleCommand(CreateSaleDto Sale):IRequest<Sale>;

public class CreateSaleCommandHandler:IRequestHandler<CreateSaleCommand,Sale>
{
    private readonly IMapper _mapper;
    private readonly ISaleRepository _SaleRepository;
    
    public CreateSaleCommandHandler(IMapper mapper, ISaleRepository SaleRepository)
    {
        _mapper = mapper;
        _SaleRepository = SaleRepository;
    }

    
    public Task<Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
         
        var Sale = _mapper.Map<Sale>(request.Sale);
        _SaleRepository.Create(Sale);
        return Task.FromResult(Sale);
    }
}