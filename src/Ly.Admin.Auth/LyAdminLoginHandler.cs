using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.Auth
{
    public class LyAdminLoginHandler : ILoginHandler
    {
        private readonly ILogger<LyAdminLoginHandler> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public LyAdminLoginHandler(ILogger<LyAdminLoginHandler> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public JwtTokenModel Hand(IEnumerable<Claim> claims, string extendData, string realName)
        { 
            var jwtConfig = AuthConfigData.AuthConfig.Jwt;

            var token = Build(claims, jwtConfig);

            _logger.LogInformation($"生成JwtToken：{token}");

            var model = new JwtTokenModel
            {
                AccessToken = token,
                ExpiresIn = jwtConfig.Expires * 60,
                RefreshToken = extendData,
                RealName = realName
            };

            return model;
        }
        private string Build(IEnumerable<Claim> claims, JwtConfig config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config.Issuer, config.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(config.Expires), signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
