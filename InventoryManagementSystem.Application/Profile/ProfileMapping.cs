using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Application.Dtos.ProductDtos;
using InventoryManagementSystem.Application.Dtos.PurchaseDtos;
using InventoryManagementSystem.Application.Dtos.SaleDtos;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Profile;

public class ProfileMapping:AutoMapper.Profile
{
    public ProfileMapping()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<CreatePurchaseDto, Purchase>();
        CreateMap<CreateSaleDto, Sale>();
    }
}