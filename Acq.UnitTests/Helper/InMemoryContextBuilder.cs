using Acq.VideoSearch.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Acq.UnitTests.Helper
{
    public static class InMemoryContextBuilder
    {
        public static AppDbContext Build()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("WeatherTestDb").Options;
            return new AppDbContext(options);
        }
    }
}
