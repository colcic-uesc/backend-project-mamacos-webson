using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using UescColcicAPI.Services.Auth;
using UescColcicAPI.Services.BD;
using BackEndAPI.Core;

namespace UescColcicAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthControler : ControllerBase
{
    private readonly IUserCRUD _userCRUD;
    private readonly ITokenGeneration _tokenGeneration;

    public AuthControler(IUserCRUD userCRUD, ITokenGeneration tokenGeneration)
    {
        _userCRUD = userCRUD;
        _tokenGeneration = tokenGeneration;
    }

    [HttpPost("/login", Name = "GetToken")]
    public IActionResult Login([FromBody] LoginDTO entity)
    {
        if (entity.UserName is null)
            return Unauthorized();
  
        var user = _userCRUD.ReadByUserName(entity.UserName);
        if (user is null){
            return Unauthorized();
        }
        if (entity.Password == user.Password){
            var token = _tokenGeneration.GenerateJwtToken();
            return Ok(new { token });
        }
        return Unauthorized();
    }

}

