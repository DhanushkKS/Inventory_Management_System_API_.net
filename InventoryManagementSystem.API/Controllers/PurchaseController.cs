using InventoryManagementSystem.Application.Commands;
using InventoryManagementSystem.Application.Queries;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers;

public class PurchasesController:ApiControllerBase
{
    private IMediator _mediator;

    public PurchasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Purchase>> GetAll()
    {
        return await _mediator.Send(new GetPurchaseListQuery());
    }

    [HttpPost]
    public async Task<Purchase> Create(CreatePurchaseCommand command)
    {
        return await _mediator.Send(command);
    }
}