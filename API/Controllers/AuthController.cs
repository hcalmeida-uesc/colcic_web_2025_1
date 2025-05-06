using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ddd_project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        _logger.LogInformation($"Login attempt for user: {request.Username}");
        
        // Validate user credentials (this is just an example)
        if (request.Username == "test" && request.Password == "password")
        {
            var token = GenerateJwtToken(request.Username);
            _logger.LogInformation($"Login successful for user: {request.Username}");
            _logger.LogDebug($"Generated token: {token}");
            return Ok(new { Token = token });
        }

        _logger.LogWarning($"Invalid login attempt for user: {request.Username}");
        return Unauthorized();
    }

    private string GenerateJwtToken(string username)
    {
        var jwtKey = _configuration["Jwt:Key"];
        var jwtIssuer = _configuration["Jwt:Issuer"];

        _logger.LogDebug($"JWT Key length: {jwtKey?.Length}");
        _logger.LogDebug($"JWT Issuer: {jwtIssuer}");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username) // Adicionar nome como claim
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtIssuer,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
