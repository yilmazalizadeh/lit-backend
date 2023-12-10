using Acq.VideoSearch.Core.Dto;
using Acq.VideoSearch.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Acq.VideoSearch.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpPost("AddForecast")]
    public async Task<IActionResult> AddWeatherForecast(WeatherCreateDto dto)
    {
        var results = await _weatherService.AddWeatherForecast(dto);
        return Ok(results);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var results = await _weatherService.GetAllWeatherForecasts();
        return Ok(results);
    }
}