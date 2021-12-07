using Microsoft.EntityFrameworkCore;

namespace Herman.Base.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<BaseDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for BaseDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}




