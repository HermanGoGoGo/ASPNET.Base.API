using Abp.Modules;
using Abp.Reflection.Extensions;
using AI5yue.Base.Localization;

namespace AI5yue.Base
{
    public class BaseCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            BaseLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = BaseConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BaseCoreModule).GetAssembly());
        }
    }
}

