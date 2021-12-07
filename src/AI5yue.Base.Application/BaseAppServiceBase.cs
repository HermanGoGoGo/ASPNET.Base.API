using Abp.Application.Services;

namespace AI5yue.Base
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BaseAppServiceBase : ApplicationService
    {
        protected BaseAppServiceBase()
        {
            LocalizationSourceName = BaseConsts.LocalizationSourceName;
        }
    }
}

