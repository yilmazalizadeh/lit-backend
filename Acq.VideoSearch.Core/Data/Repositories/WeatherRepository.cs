using Acq.VideoSearch.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Acq.VideoSearch.Core.Data.Repositories;

public interface IWeatherRepository
{
    Task<Weather> Add(Weather weather, CancellationToken token);
    Task Update(Weather weather, CancellationToken token);
    Task Delete(string id, CancellationToken token);
    Task<Weather?> Get(string id, CancellationToken token);
    Task<IList<Weather>> GetAll(CancellationToken token);
}

public class WeatherRepository : IWeatherRepository
{
    private readonly AppDbContext _dbContext;

    public WeatherRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Weather> Add(Weather weather, CancellationToken token)
    {
        try
        {
            var entity = await _dbContext.Weathers.AddAsync(weather, token);
            await SaveChanges(token);
            return entity.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task Update(Weather weather, CancellationToken token)
    {
        var entity = await Get(weather.UniqId, token);

        //TODO: handle not found to update
        if (entity != null)
        {
            _dbContext.Update(weather);
            await SaveChanges(token);
        }
    }

    public async Task Delete(string id, CancellationToken token)
    {
        var entity = await Get(id, token);

        //TODO: handle not found to delete
        if (entity != null)
        {
            _dbContext.Remove(entity);
            await SaveChanges(token);
        }
    }

    public async Task<Weather?> Get(string id, CancellationToken token)
    {
        return await _dbContext.Weathers.FirstOrDefaultAsync(weather => weather.UniqId == id, token);
    }

    //TODO: add pagination support
    public async Task<IList<Weather>> GetAll(CancellationToken token)
    {
        return await _dbContext.Weathers.ToListAsync(token);
    }

    private async Task SaveChanges(CancellationToken token)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}