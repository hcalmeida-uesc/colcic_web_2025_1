using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ddd_project.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenDebugController : ControllerBase
{
    private readonly ILogger<TokenDebugController> _logger;

    public TokenDebugController(ILogger<TokenDebugController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult DebugToken()
    {
        try
        {
            // Tenta extrair o token de autorização
            string authHeader = Request.Headers["Authorization"].ToString();
            _logger.LogInformation($"Authorization header: {authHeader}");

            // Verifica se o cabeçalho está presente
            if (string.IsNullOrEmpty(authHeader))
            {
                return BadRequest(new { error = "Cabeçalho de autorização não encontrado" });
            }

            // Verifica se o formato do cabeçalho está correto (Bearer + token)
            if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { 
                    error = "Formato incorreto. Deve começar com 'Bearer '",
                    received = authHeader
                });
            }

            // Extrai o token após "Bearer "
            string token = authHeader.Substring("Bearer ".Length).Trim();

            // Verifica se o token está vazio
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { error = "Token está vazio" });
            }

            // Verifica se o token tem o formato JWT básico (três partes separadas por pontos)
            var parts = token.Split('.');
            if (parts.Length != 3)
            {
                return BadRequest(new { 
                    error = "Token não parece ser um JWT válido (deve ter 3 partes separadas por pontos)",
                    parts = parts.Length
                });
            }

            // Verifica se cada parte contém apenas caracteres válidos de Base64Url
            Regex base64UrlPattern = new Regex(@"^[A-Za-z0-9_-]*$");
            for (int i = 0; i < parts.Length; i++)
            {
                if (!base64UrlPattern.IsMatch(parts[i]))
                {
                    return BadRequest(new { 
                        error = $"A parte {i+1} do token contém caracteres inválidos para Base64Url",
                        part = parts[i]
                    });
                }
            }

            // Se chegou até aqui, o token parece ter o formato correto
            return Ok(new { 
                message = "O token parece ter o formato correto",
                tokenParts = new {
                    header = parts[0],
                    payload = parts[1],
                    signature = parts[2]
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao analisar o token");
            return StatusCode(500, new { error = $"Erro interno: {ex.Message}" });
        }
    }
}
