using System.Text;
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

    [HttpGet("getfromftream")]
    public async Task<IActionResult> GetFromStream()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string url = "http://localhost:5126/SecondService/getfromstream"; // Replace with your API endpoint URL

            // Create a MemoryStream with sample data
            byte[] data = Encoding.UTF8.GetBytes("Hello, StreamContent!");
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                // Create StreamContent from the FileStream
                StreamContent streamContent = new StreamContent(memoryStream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                
                // Send POST request
                HttpResponseMessage response = await httpClient.PostAsync(url, streamContent);
               

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return Ok("Response: " + responseBody);
                }
                else
                {
                    return Ok("Request failed with status code: " + response.StatusCode);
                }
            }
        }

    }
}
