using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Herman.Base.Configuration;
using Herman.Base.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace Herman.Base.API.Startup
{
    [DependsOn(
        typeof(BaseApplicationModule), 
        typeof(BaseEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class BaseWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BaseWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(BaseConsts.ConnectionStringName);

            //Configuration.Navigation.Providers.Add<BaseNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(BaseApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BaseWebModule).Assembly);
        }
    }
}




