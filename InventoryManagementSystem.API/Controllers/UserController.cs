using System.Security.Claims;
using InventoryManagementSystem.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.API.Controllers;

public class UserController:ApiControllerBase
{

    [HttpGet("Admin")]
    [Authorize]
    public IActionResult AdminLog()
    {
        var currentUser = GetCurrentUser();
        return Ok($"Hi {currentUser.UserName}");
    }
    
    [HttpGet("public")]
    public IActionResult Public()
    {
        return Ok("Public Access");
    }

    private User GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if (identity!=null)
        {
            var userClaims = identity.Claims;
            return new User()
            {
                Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value

            };
        }

        return null;
    }
}