using Abp.Application.Services;

namespace Herman.Base
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

        protected string AccessUserName
        {
            get
            {
                // if (!string.IsNullOrEmpty(_userName) && _accessTokenExpires.HasValue && _accessTokenExpires.Value > DateTime.UtcNow)
                //     return _userName;
                var userName = "Herman";

                return userName;
            }
        }

        protected string AccessPassWord
        {
            get
            {
                // if (!string.IsNullOrEmpty(_userName) && _accessTokenExpires.HasValue && _accessTokenExpires.Value > DateTime.UtcNow)
                //     return _userName;
                var passWord = "123456";

                return passWord;
            }
        }
    }
}



