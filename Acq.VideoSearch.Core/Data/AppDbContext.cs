using Acq.VideoSearch.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Acq.VideoSearch.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Weather> Weathers => Set<Weather>();
    }
}
