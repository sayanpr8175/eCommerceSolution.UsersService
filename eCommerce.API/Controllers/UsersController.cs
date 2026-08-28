using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }


    // Get /api/Users/{userID}
    [HttpGet("{userID}")]
    public async Task<IActionResult> GetUserByUserID(Guid userID)
    {
        if(userID == Guid.Empty)
        {
            return BadRequest("Invalid User ID");
        }

        UserDTO? userResponse = await _usersService.GetUserByUserID(userID);

        if(userResponse == null)
        {
            return NotFound(userResponse);
        }

        return Ok(userResponse);

        // eCommerceUsers
        // postgres
        //5432
    }

}
