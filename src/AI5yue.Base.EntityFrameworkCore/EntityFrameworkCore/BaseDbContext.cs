using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AI5yue.Base.EntityFrameworkCore
{
    public class BaseDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public BaseDbContext(DbContextOptions<BaseDbContext> options) 
            : base(options)
        {

        }
    }
}


