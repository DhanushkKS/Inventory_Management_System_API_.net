using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers
{
    [ApiController]
    [Route(BaseApiPath+"/[controller]")]
    [EnableCors("AllowOrigin")]
    public class ApiControllerBase : ControllerBase
    {
        private const string BaseApiPath = "/inventoryManagementSystem/api/v1";
        
    }


    
}