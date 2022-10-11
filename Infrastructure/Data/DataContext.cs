using Microsoft.EntityFrameworkCore;
using SuperHero.Core.Entities;

namespace SuperHero.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<SuperHeroModel> SuperHeroes => Set<SuperHeroModel>();
    }
}
