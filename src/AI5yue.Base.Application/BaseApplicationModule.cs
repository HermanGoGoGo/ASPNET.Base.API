using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AI5yue.Base
{
    [DependsOn(
        typeof(BaseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BaseApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseApplicationModule).GetAssembly());
        }
    }
}

