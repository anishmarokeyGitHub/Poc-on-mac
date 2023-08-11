using Microsoft.AspNetCore.Mvc;

namespace ANVR.Http.FirstService.Controllers;

[ApiController]
[Route("[controller]")]
public class FirstServiceController : ControllerBase
{

    private readonly HttpClient _httpClient;
    private readonly ILogger<FirstServiceController> _logger;

    public FirstServiceController(ILogger<FirstServiceController> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _httpClient.GetAsync("http://localhost:5126/SecondService");
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            // Process the response body
            
            return Ok("Hell0 from first service" + responseBody);
        }
        else
        {
            // Handle error cases
            return StatusCode((int)response.StatusCode);
        } 
    }
}
