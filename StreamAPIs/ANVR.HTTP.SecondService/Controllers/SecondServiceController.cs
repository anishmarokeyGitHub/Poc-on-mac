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
}
