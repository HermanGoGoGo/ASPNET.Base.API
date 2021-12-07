using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Herman.Base.EntityFrameworkCore
{
    [DependsOn(
        typeof(BaseCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class BaseEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseEntityFrameworkCoreModule).GetAssembly());
        }
    }
}



