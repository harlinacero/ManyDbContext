using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoulleteApi.Entities;
using System;

namespace RoulleteApi.DataAccess
{
    public class PostgreSQLDbContext : DbContext
    {
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Host=localhost;Database=Router;Username=admin;Password=1234; Port=5432")
        //        .EnableSensitiveDataLogging(true)
        //        .UseLoggerFactory(new LoggerFactory())                 
        //        ;
        //}

        //protected OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}

        public DbSet<Roulette> Roulette { get; set; }
        //public DbSet<WeatherForecast> WeatherForecast { get; set; }
        //public virtual DbSet<TEntity> Set<TEntity>() where TEntity : class
        //{
        //    return (DbSet<TEntity>)((IDbSetCache)this).GetOrAddSet(DbContextDependencies.SetSource, typeof(TEntity));
        //}
        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }

}
