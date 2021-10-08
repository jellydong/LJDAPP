using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ly.Admin.Auth
{
    /// <summary>
    /// 自定义jwt令牌验证处理器
    /// </summary>
    public class LyAdminJwtSecurityTokenHandler : JwtSecurityTokenHandler, ISecurityTokenValidator
    {
        public LyAdminJwtSecurityTokenHandler()
        {
        }
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            var jwtConfig = AuthConfigData.AuthConfig.Jwt;

            validationParameters.ValidIssuer = jwtConfig.Issuer;
            validationParameters.ValidAudience = jwtConfig.Audience;
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

            return base.ValidateToken(token, validationParameters, out validatedToken);
        }
    }
}
