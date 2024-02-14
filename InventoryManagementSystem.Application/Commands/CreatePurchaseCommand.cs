using AutoMapper;
using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Dtos.PurchaseDtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Commands;

public record CreatePurchaseCommand(CreatePurchaseDto Purchase):IRequest<Purchase>;

public class CreatePurchaseCommandHandler:IRequestHandler<CreatePurchaseCommand,Purchase>
{
    private readonly IMapper _mapper;
    private readonly IPurchaseRepository _PurchaseRepository;
    
    public CreatePurchaseCommandHandler(IMapper mapper, IPurchaseRepository PurchaseRepository)
    {
        _mapper = mapper;
        _PurchaseRepository = PurchaseRepository;
    }

    
    public Task<Purchase> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var Purchase = _mapper.Map<Purchase>(request.Purchase);
        _PurchaseRepository.Create(Purchase);
        return Task.FromResult(Purchase);
    }
}