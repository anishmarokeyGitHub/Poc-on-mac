using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ANVR.HTTP.SecondService.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondServiceController : ControllerBase
{

    private readonly ILogger<SecondServiceController> _logger;

    public SecondServiceController(ILogger<SecondServiceController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Get() => "Response from second service";

    [HttpPost("getfromstream")]
    public async Task<IActionResult> GetFromStream([FromBody] Stream inputStream)
    {
        // You can directly work with the `inputStream` here
        using (StreamReader reader = new StreamReader(inputStream))
        {
            string requestData = await reader.ReadToEndAsync();
            // Process the data from the stream (requestData)
            return Ok("Stream data processed successfully.");
        }
    }
}
