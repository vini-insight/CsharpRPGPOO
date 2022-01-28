using Microsoft.EntityFrameworkCore;
using Src.Domain.Entities;

namespace Src.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Hero> Heros { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}