using Acq.UnitTests.Helper;
using Acq.VideoSearch.Core.Data.Repositories;
using Acq.VideoSearch.Core.Models;

namespace Acq.UnitTests
{
    public class WeatherRepositoryTest
    {
        private WeatherRepository _weatherRepo;

        [SetUp]
        public void Setup()
        {
            var dbContext = InMemoryContextBuilder.Build();
            _weatherRepo = new WeatherRepository(dbContext);
        }

        [Test]
        public async Task WeatherForecastCreationTest()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1000);
            var testWeather = new Weather() { Date = DateTime.Now, TempC = 18.4f, Summary = "Cool Weather" };
            var itemId = await _weatherRepo.Add(testWeather, tokenSource.Token);
            Assert.That(itemId,Is.Not.Null);
        }
        [Test]
        public async Task WeatherForecastFetchTest()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1000);
            var testWeather = new Weather() { Date = DateTime.Now, TempC = 18.4f, Summary = "Cool Weather" };
            var itemId = await _weatherRepo.Add(testWeather, tokenSource.Token);
            var results = await _weatherRepo.Get(itemId, tokenSource.Token);
            Assert.That(results, Is.Not.Null);
        }
        [Test]
        public async Task WeatherForecastFetchAllTest()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(1000);
            var testWeather = new Weather() { Date = DateTime.Now, TempC = 18.4f, Summary = "Cool Weather" };
            await _weatherRepo.Add(testWeather, tokenSource.Token);
            var results = await _weatherRepo.GetAll(tokenSource.Token);
            Assert.That(results, Has.Count.EqualTo(1));
        }
        //TODO: Add remaining tests for crud operations
    }
}