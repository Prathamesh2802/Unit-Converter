using Microsoft.AspNetCore.Mvc;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Controllers;

[ApiController]
[Route("/")]
public class ConversionController : ControllerBase
{
    private readonly ConversionService _service;

    public ConversionController(ConversionService service)
    {
        _service = service;
    }

    [HttpGet]
     
    public IActionResult ServerStatus()
    {
        return Ok(new { Status = 200, message="Server is Working Fine" });
    }

    [HttpPost("api/convert")]
    public IActionResult Convert(ConvertRequest request)
    {
        var result = _service.Convert(
            request.Category,
            request.FromUnit,
            request.ToUnit,
            request.Value);

        return Ok(new
        {
            OriginalValue = request.Value,
            FromUnit = request.FromUnit,
            ToUnit = request.ToUnit,
            ConvertedValue = Math.Round(result,4)
        });
    }
}