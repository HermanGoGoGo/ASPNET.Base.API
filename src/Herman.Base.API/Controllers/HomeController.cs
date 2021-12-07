using System;
using System.Threading.Tasks;
using Herman.Base.API.Filter.ApiResult.Model;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Herman.Base.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : BaseControllerBase
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        [ApiVersion("2.0")]
        [Authorize]
        [Route("dataVerification")]
        [SwaggerOperation("DataVerification")]
        [HttpPost]
        public  ApiResultModel<string> DataVerification([FromBody] string dataVerificationApiData)
        {
            try
            {
                return new ApiResultModel<string>()
                {
                    Data = "Hello",
                    Status = System.Net.HttpStatusCode.OK,
                    StatusCode = 200,
                };
            }
            catch (ValidationException e)
            {
                return BadResult(e.Message);
            }
            catch (Exception e)
            {
                return BadResult(e.Message);
            }
        }

        [ApiVersion("1.0")]
        [Authorize]
        [Route("dataVerification")]
        [SwaggerOperation("DataVerification")]
        [HttpPost]
        public ApiResultModel<string> DataVerification02([FromBody] string dataVerificationApiData)
        {
            try
            {
                return new ApiResultModel<string>()
                {
                    Data = "Hello",
                    Status = System.Net.HttpStatusCode.OK,
                    StatusCode = 200,
                };
            }
            catch (ValidationException e)
            {
                return BadResult(e.Message);
            }
            catch (Exception e)
            {
                return BadResult(e.Message);
            }
        }

    }
}



