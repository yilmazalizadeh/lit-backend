using Acq.VideoSearch.Core.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Acq.IntegrityTests.Base;

public class IntegrationTests
{
    protected readonly HttpClient TestClient;

    protected IntegrationTests()
    {
        var configuration = ConfigBuilder.Build();
        var endpointUri = configuration["endpointUri"];
        var primaryKey = configuration["primaryKey"];
        var dbName = configuration["dbName"];
        var appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                if (descriptor != null) services.Remove(descriptor);
                services.AddDbContext<AppDbContext>(opt => opt.UseCosmos(endpointUri, primaryKey, dbName));
                services.BuildServiceProvider();
            });
        });
        TestClient = appFactory.CreateClient();
    }
}