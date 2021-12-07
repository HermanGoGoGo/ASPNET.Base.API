using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Herman.Base.API.Filter.ApiResult.Model;
using Herman.Base.API.Filter.ApiResult.Model.Generic;
using Herman.Base.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using ValidationException = FluentValidation.ValidationException;

namespace Herman.Base.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccessController : BaseControllerBase
    {
        private readonly AccessAppService _accessAppService;

        public AccessController(AccessAppService accessAppService,ILogger<HomeController> logger) : base(logger)
        {
            _accessAppService = accessAppService;
        }


        [ApiVersion("1.0")]
        [Route("getAccessToken")]
        [SwaggerOperation("getAccessToken")]
        [HttpPost]
        public async Task<ApiResultModel> GetAccessToken([FromForm][Required] string username, [FromForm][Required] string password)
        {
            try
            {
                var accessOutput = await _accessAppService.AccessAsync(new AccessDto()
                {
                    Username = username,
                    Password = password,
                });
                return SuccessResult(accessOutput);
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



