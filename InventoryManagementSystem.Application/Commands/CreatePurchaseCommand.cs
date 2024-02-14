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
    private readonly IPurchaseRepository _purchaseRepository;
    
    public CreatePurchaseCommandHandler(IMapper mapper, IPurchaseRepository purchaseRepository)
    {
        _mapper = mapper;
        _purchaseRepository = purchaseRepository;
    }

    
    public Task<Purchase> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
         
        var purchase = _mapper.Map<Purchase>(request.Purchase);
        _purchaseRepository.Create(purchase);
        return Task.FromResult(purchase);
    }
}