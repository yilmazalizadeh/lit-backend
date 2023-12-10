using Acq.VideoSearch.Core.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acq.IntegrityTests.Base;

public static class TestContextBuilder
{
    public static async Task<ServiceCollection> AddDbContext(IConfiguration configuration, ServiceCollection services)
    {
        var endpointUri = configuration["endpointUri"];
        var primaryKey = configuration["primaryKey"];
        var cosmosClient = new CosmosClient(endpointUri, primaryKey,
            new CosmosClientOptions() { ApplicationName = "WeatherDevDb" });
        await cosmosClient.CreateDatabaseIfNotExistsAsync("WeatherDevDb");
        services.AddDbContext<AppDbContext>(opt => opt.UseCosmos(endpointUri, primaryKey, "WeatherDevDb"));
        return services;
    }
}