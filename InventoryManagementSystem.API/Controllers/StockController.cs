using InventoryManagementSystem.Application.Commands;
using InventoryManagementSystem.Application.Queries;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers;

public class StockController:ApiControllerBase
{
    private IMediator _mediator;

    public StockController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Stock>> GetAll()
    {
        return await _mediator.Send(new GetStockListQuery());
    }

    [HttpGet("getByProductId")]
    public async Task<Stock> GetByProductId([FromQuery] int productId)
    {
        return await _mediator.Send(new GetStockByProductIdQuery(productId));
    }

    [HttpPost("create")]
    public async Task<Stock> Create(CreateStockCommand command)
    {
        return await _mediator.Send(command);
    }
}