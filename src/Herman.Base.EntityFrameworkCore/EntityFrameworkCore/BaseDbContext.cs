using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Herman.Base.EntityFrameworkCore
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




