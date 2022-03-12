using Microsoft.EntityFrameworkCore;
using Npgsql;
using RoulleteApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RoulleteApi.DataAccess
{
    public class PostgreSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly PostgreSQLDbContext _appDbContext;
        public PostgreSQLRepository(PostgreSQLDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public TEntity Add(TEntity value)
        {
            _appDbContext.Add(value);
            return value;
        }

        public TEntity Update(TEntity value)
        {
            _appDbContext.Update(value);
            return value;
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Get(string id)
        {
           return _appDbContext.Find<TEntity>(new object[] { id });
        }

        public IEnumerable<TEntity> GetAll()
        {
            var a = _appDbContext.Model.GetEntityTypes().Select(t => t.ClrType).ToList();
            //var b = a.ToList<TEntity>();

            //return List<TEntity>();
            return null;
           
        }

        
    }

}
