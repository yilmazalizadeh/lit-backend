using Acq.VideoSearch.Core.Data.Repositories;
using Acq.VideoSearch.Core.Dto;
using Acq.VideoSearch.Core.Helper;
using Acq.VideoSearch.Core.Models;
using AutoMapper;

namespace Acq.VideoSearch.Core.Service;

public interface IWeatherService
{
    Task<WeatherReadDto> AddWeatherForecast(WeatherCreateDto weatherDto);

    Task<WeatherReadDto?> GetWeatherForecast(string id);

    Task<IEnumerable<WeatherReadDto>?> GetAllWeatherForecasts();
    //TODO: add rest of the services
}

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _repo;
    private readonly IMapper _mapper;

    public WeatherService(IMapper mapper, IWeatherRepository repo)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<WeatherReadDto> AddWeatherForecast(WeatherCreateDto weatherDto)
    {
        var weather = _mapper.Map<Weather>(weatherDto);
        var token = CancellationTokenBuilder.Build(10000);
        var results = await _repo.Add(weather, token);
        return _mapper.Map<WeatherReadDto>(results);
    }

    public async Task<WeatherReadDto?> GetWeatherForecast(string id)
    {
        var token = CancellationTokenBuilder.Build(10000);
        var result = await _repo.Get(id, token);
        return result == null ? null : _mapper.Map<WeatherReadDto>(result);
    }

    public async Task<IEnumerable<WeatherReadDto>?> GetAllWeatherForecasts()
    {
        var token = CancellationTokenBuilder.Build(10000);
        //TODO: Add pagination
        var result = await _repo.GetAll(token);
        return result.Select(weather => _mapper.Map<WeatherReadDto>(weather));
    }
}