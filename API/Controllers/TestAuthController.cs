using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ddd_project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestAuthController : ControllerBase
{
    private readonly ILogger<TestAuthController> _logger;

    public TestAuthController(ILogger<TestAuthController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        return Ok(new { message = "Este endpoint é público" });
    }

    [HttpGet("secured")]
    [Authorize]
    public IActionResult GetSecured()
    {
        _logger.LogInformation("Um usuário autenticado acessou o endpoint seguro");
        var username = User.Identity?.Name;
        return Ok(new { message = $"Este endpoint é protegido. Olá, {username}!" });
    }
}
