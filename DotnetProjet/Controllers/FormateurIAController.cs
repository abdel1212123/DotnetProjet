using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DotnetProjet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormateurIAController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpFactory;

    public FormateurIAController(IConfiguration config, IHttpClientFactory httpFactory)
    {
        _config = config;
        _httpFactory = httpFactory;
    }

    [HttpPost("session-token")]
    public async Task<IActionResult> GetSessionToken()
    {
        var apiKey = _config["Anam:ApiKey"];
        if (string.IsNullOrEmpty(apiKey))
            return BadRequest(new { message = "Clé API Anam manquante." });

        var body = new
        {
            personaConfig = new
            {
                personaId = "ae3e4d15-905c-5480-a57f-44f202967fe0"
            }
        };

        var json = JsonSerializer.Serialize(body);

        var client = _httpFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.anam.ai/v1/auth/session-token");
        request.Headers.Add("Authorization", $"Bearer {apiKey}");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode, new { message = "Erreur Anam", details = content });

        return Content(content, "application/json");
    }
}