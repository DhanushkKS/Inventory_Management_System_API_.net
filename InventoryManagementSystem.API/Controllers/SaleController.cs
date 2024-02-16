using InventoryManagementSystem.Application.Commands;
using InventoryManagementSystem.Application.Queries;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers;

public class SaleController:ApiControllerBase
{
    private IMediator _mediator;

    public SaleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Sale>> GetAll()
    {
        return await _mediator.Send(new GetSaleListQuery());
    }

    [HttpPost]
    public async Task<Sale> Create(CreateSaleCommand command)
    {
        return await _mediator.Send(command);
    }
}