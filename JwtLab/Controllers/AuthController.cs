using JwtLab.Models;
using JwtLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtLab.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string email)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = username,
            Email = email,
            Role = "Admin"
        };

        var token = _jwtService.GenerateToken(user);

        return Ok(new { Token = token });
    }
}