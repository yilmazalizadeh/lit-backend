using Acq.IntegrityTests.Base;
using Acq.IntegrityTests.Helper;
using Acq.VideoSearch.Core.Dto;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace Acq.IntegrityTests;

public class WeatherServiceTest : IntegrationTests
{
    [Fact]
    public async Task GetAll_AllWeatherForecast_ReturnIListWeatherReadDto()
    {
        // Arrange

        // Act
        var response = await TestClient.GetAsync("WeatherForecast/GetAll");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.ReadFromJsonAsync<IEnumerable<WeatherReadDto>>().Result.Should().HaveCountGreaterOrEqualTo(1);
    }

    [Fact]
    public async Task Post_AddWeatherForecast_ReturnWeatherReadDto()
    {
        // Arrange
        var inputItem = new WeatherCreateDto()
        {
            Date = DateTime.Now.ToUniversalTime(),
            TempC = RandomTempGenerator.Generate(5f, 30f),
            Summary = $"Test Data - {new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"
        };
        var content = ObjectConvertor.ConvertToStringContent(inputItem);

        // Act
        var response = await TestClient.PostAsync("WeatherForecast/AddForecast",
            content);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.ReadFromJsonAsync<WeatherReadDto>().Result.Should().NotBeNull();
    }
}