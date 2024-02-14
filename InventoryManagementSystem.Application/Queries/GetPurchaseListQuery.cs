using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Repositories;
using InventoryManagementSystem.Domain.Entities;
using MediatR;

namespace InventoryManagementSystem.Application.Queries;

public record GetPurchaseListQuery():IRequest<List<Purchase>>;

public class GerPurchaseListQueryHandler : IRequestHandler<GetPurchaseListQuery,List< Purchase>>
{
    private readonly IPurchaseRepository _PurchaseRepository;

    public GerPurchaseListQueryHandler(IPurchaseRepository PurchaseRepository)
    {
        _PurchaseRepository = PurchaseRepository;
    }

    public Task<List<Purchase>> Handle(GetPurchaseListQuery request, CancellationToken cancellationToken)
    {
        List<Purchase> Purchases = _PurchaseRepository.GetAll();
        return Task.FromResult(Purchases);
    }
}