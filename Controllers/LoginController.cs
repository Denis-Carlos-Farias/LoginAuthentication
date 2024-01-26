using LoginAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginAuthentication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public LoginController(ITokenService tokenService, ILogger<LoginController> logger)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult LoginAsync(Login userLogin)
    {
        if (userLogin.UserName.Equals("user", StringComparison.OrdinalIgnoreCase) ||
            userLogin.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            return Ok(_tokenService.GerarTokenJwt($"{userLogin.UserName}-demo", userLogin.UserName));
        }

        return BadRequest("username or password is invalid");
    }
}
