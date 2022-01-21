using IdentityModel;
using Ly.Admin.API.Config.Attribute;
using Ly.Admin.Auth;
using Ly.Admin.IServices;
using Ly.Admin.Resources;
using Ly.Admin.Services;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ly.Admin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ILoginHandler _loginHandler;
        private readonly IUserService _userService;
        private readonly ILoginInfo _loginInfo;

        public AuthController(ILogger<AuthController> logger, ILoginHandler loginHandler, IUserService userService, ILoginInfo loginInfo)
        {
            _logger = logger;
            _loginHandler = loginHandler;
            _userService = userService;
            _loginInfo = loginInfo;
        }

        /// <summary>
        /// 测试获取Token
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetToken")]
        public JwtTokenModel GetToken()
        {
            try
            {
                #region 第一版
                //var jwtConfig = AuthConfigData.AuthConfig.Jwt;
                ////定义发行人issuer
                //string iss = jwtConfig.Issuer;
                ////定义受众人audience
                //string aud = jwtConfig.Audience;

                ////定义许多种的声明Claim,信息存储部分,Claims的实体一般包含用户和一些元数据
                //IEnumerable<Claim> claims = new Claim[]
                //{
                //new Claim(JwtClaimTypes.Id,"1"),
                //new Claim(JwtClaimTypes.Name,"jelly"),
                //};
                ////notBefore  生效时间
                //// long nbf =new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                //var nbf = DateTime.UtcNow;
                ////expires   //过期时间
                //// long Exp = new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds();
                //var Exp = DateTime.UtcNow.AddSeconds(1000);
                ////signingCredentials  签名凭证
                //string sign = jwtConfig.Key; //SecurityKey 的长度必须 大于等于 16个字符
                //var secret = Encoding.UTF8.GetBytes(sign);
                //var key = new SymmetricSecurityKey(secret);
                //var signcreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //var jwt = new JwtSecurityToken(issuer: iss, audience: aud, claims: claims, notBefore: nbf, expires: Exp, signingCredentials: signcreds);
                //var JwtHander = new JwtSecurityTokenHandler();
                //var token = JwtHander.WriteToken(jwt);
                //return Ok(new
                //{
                //    access_token = token,
                //    token_type = "Bearer",
                //}); 
                #endregion
                IEnumerable<Claim> claims = new Claim[]
                {
                    new Claim(ClaimsName.AccountId,"1"),
                    new Claim(ClaimsName.AccountName,"jelly"),
                    new Claim(ClaimsName.AccountType,AccountTypeEnum.USER.ToString()),
                };
                var jwtmodel = _loginHandler.Hand(claims, Guid.NewGuid().ToString(), "jelly");
                return jwtmodel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns></returns>
        [HttpGet("VerifyCode")]
        public async Task<ResponseResult> VerifyCode(int length = 4)
        {
            return await _userService.CreateVerifyCode(length);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ResponseResult> Login(LoginInfoModel loginInfo)
        {
            _logger.LogInformation($"用户登录{JsonConvert.SerializeObject(loginInfo)}");
            //todo: 赋值 ip 登录设备信息
            var result = await _userService.Login(loginInfo);
            return LoginHandle(result);
        }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpGet("RefreshToken")]
        [Authorize]
        public async Task<ResponseResult> RefreshToken(string refreshToken)
        {
            var result = await _userService.RefreshToken(refreshToken);
            return LoginHandle(result);
        }

        /// <summary>
        /// 获取认证信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("AuthInfo")]
        [Authorize]
        [PermissionValidate("AuthInfo")]
        public async Task<ResponseResult> AuthInfo()
        {
            return await _userService.GetAuthInfo(_loginInfo.AccountId, _loginInfo.Platform);
        }

        [HttpGet("HelloWorld")]
        public string HelloWorld()
        {
            return _userService.HelloWorld();
        }


        /// <summary>
        /// 登录处理
        /// </summary>
        private ResponseResult LoginHandle(ResponseResult responseResult)
        {
            if (responseResult.Code.Equals(ResultEnum.SUCCESS))
            {
                var model = responseResult as ResponseResult<LoginResultModel>;

                var account = model.Result.UserInfo;
                var loginInfo = model.Result.AuthResource;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsName.AccountId, account.Id.ToString()),
                    new Claim(ClaimsName.AccountName, account.RealName),
                    new Claim(ClaimsName.AccountType, ((int)AccountTypeEnum.USER).ToString()),
                    new Claim(ClaimsName.Platform,((int)loginInfo.Platform).ToString() ),
                    new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
                };
                var jwtmodel = _loginHandler.Hand(claims, loginInfo.RefreshToken, account.RealName);
                return new ResponseResult<JwtTokenModel>(ResultEnum.SUCCESS, "", jwtmodel);
            }
            return new ResponseResult(ResultEnum.ERROR, responseResult.Message);
        }

    }
}
