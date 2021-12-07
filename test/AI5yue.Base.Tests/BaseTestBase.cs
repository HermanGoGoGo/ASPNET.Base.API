using System;
using System.Threading.Tasks;
using Abp.TestBase;
using AI5yue.Base.EntityFrameworkCore;
using AI5yue.Base.Tests.TestDatas;

namespace AI5yue.Base.Tests
{
    public class BaseTestBase : AbpIntegratedTestBase<BaseTestModule>
    {
        public BaseTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<BaseDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<BaseDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<BaseDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BaseDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<BaseDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<BaseDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<BaseDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<BaseDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}


