using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AI5yue.Base.Web.Startup;
namespace AI5yue.Base.Web.Tests
{
    [DependsOn(
        typeof(BaseWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class BaseWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseWebTestModule).GetAssembly());
        }
    }
}

