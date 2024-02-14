using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [ApiController]
    [Route(BaseApiPath+"/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private const string BaseApiPath = "/inventoryManagementSystem/api/v1";
        
    }


    
}