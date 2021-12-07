using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Herman.Base.Authorization
{
    public class AccessAppService : BaseAppServiceBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AccessAppService> _logger;

        public AccessAppService(JwtSettings jwtSettings, ILogger<AccessAppService> logger)
        {
            _jwtSettings = jwtSettings;
            _logger = logger;
            _logger = logger;
        }

        public async Task<AccessOutput> AccessAsync(AccessDto param)
        {
            if (!AccessUserName.Equals(param?.Username)||!AccessPassWord.Equals(param?.Password))
            {
                throw new ValidationException($"用户名或密码错误");
            }

            _logger.LogInformation($"user: {param?.Username} 登录系统");
            return await Task.FromResult(GetToken(param));
        }

        private AccessOutput GetToken(AccessDto user)
        {
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,user.Username),
                        new Claim(ClaimTypes.NameIdentifier,user.Username),
                        new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                        new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddSeconds(_jwtSettings?.ExpireSeconds??3600)).ToUnixTimeSeconds().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                        new Claim(JwtRegisteredClaimNames.Aud,_jwtSettings.Audience),
                    };

            var token = new JwtSecurityToken(new JwtHeader(
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)), SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new AccessOutput()
            {
                UserName = user.Username,
                ExpireSeconds = _jwtSettings?.ExpireSeconds ?? 3600,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}