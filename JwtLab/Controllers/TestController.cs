using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtLab.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    // Сюди пускатимуть ТІЛЬКИ з токеном
    [Authorize]
    [HttpGet("secret")]
    public IActionResult GetSecretData()
    {
        var name = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value;
        return Ok($"Привіт, {name}! Ти бачиш секретні дані, бо маєш токен.");
    }
    
    // Сюди пускатимуть усіх
    [HttpGet("public")]
    public IActionResult GetPublicData()
    {
        return Ok("Це бачать усі.");
    }
}