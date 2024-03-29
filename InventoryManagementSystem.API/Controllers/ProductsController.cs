using InventoryManagementSystem.Application.Commands;
using InventoryManagementSystem.Application.Queries;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers;

public class ProductsController:ApiControllerBase
{
    private IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Products API

    

   
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
           var products= await _mediator.Send(new GetProductListQuery());
           return Ok(products);
    }

    [HttpPost("create")]
    public async Task<Product> Create(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }
    #endregion
}