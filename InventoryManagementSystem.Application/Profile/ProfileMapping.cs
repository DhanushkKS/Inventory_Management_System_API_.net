using InventoryManagementSystem.Application.Dtos;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Profile;

public class ProfileMapping:AutoMapper.Profile
{
    public ProfileMapping()
    {
        CreateMap<CreateProductDto, Product>();
    }
}