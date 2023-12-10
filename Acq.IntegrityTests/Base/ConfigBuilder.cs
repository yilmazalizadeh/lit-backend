using Microsoft.Extensions.Configuration;

namespace Acq.IntegrityTests.Base;

public static class ConfigBuilder
{
    public static IConfiguration Build()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

        return builder.Build();
    }
}