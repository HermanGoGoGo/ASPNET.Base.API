using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Herman.Base.Authorization;
using Microsoft.Extensions.Configuration;

namespace Herman.Base
{
    [DependsOn(
        typeof(BaseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BaseApplicationModule : AbpModule
    {
        private readonly IConfiguration _configuration;

        public BaseApplicationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseApplicationModule).GetAssembly());
            JwtSettings jwtSettings = new JwtSettings();
            _configuration.Bind("JwtSettings", jwtSettings);
            IocManager.IocContainer.Register(Component.For<JwtSettings>().Instance(jwtSettings));
        }
    }
}



