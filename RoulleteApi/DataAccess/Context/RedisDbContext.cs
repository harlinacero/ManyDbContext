using Microsoft.EntityFrameworkCore;

namespace RoulleteApi.DataAccess
{
    public class RedisDbContext : DbContext
    {
        public RedisDbContext(DbContextOptions<RedisDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }

}
