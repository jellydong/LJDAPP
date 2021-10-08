using AutoMapper;
using Ly.Admin.IRepositories;
using Ly.Admin.IServices;
using Ly.Admin.Model;
using Ly.Admin.Resources;
using Ly.Admin.Util;
using Ly.Admin.Util.Cache;
using Ly.Admin.Util.Configuration;
using Ly.Admin.Util.Enum;
using Ly.Admin.Util.Helper;
using Ly.Admin.Util.Model;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ly.Admin.Services
{
    public class UserService : BaseService<SysUser>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<LyAdminOptions> _lyAdminOptions;

        public UserService(IUserRepository userRepository, IUnitOfWork iUnitOfWork, IAuthRepository authRepository, IMapper mapper, IOptions<LyAdminOptions> lyAdminOptions) : base(userRepository, iUnitOfWork)
        {
            _userRepository = userRepository;
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
            _lyAdminOptions = lyAdminOptions;
            _authRepository = authRepository;
        }

        public async Task<ResponseResult> CreateVerifyCode(int length)
        {
            var model = new VerifyCodeModel
            {
                Id = Guid.NewGuid().ToString(),
                Code = ValidateCodeHelper.CreateBase64String(out string code, length)
            };

            //把验证码放到内存缓存中，有效期10分钟
            var key = $"{GlobalSettings.LyAdminOptions.DefaultAppKeys.VerifyCode}:{model.Id}";
            CacheHelper.Cache.SetCache(key, code, TimeSpan.FromMinutes(10));

            return await Task.FromResult(new ResponseResult<VerifyCodeModel>(true, model));
        }
        public string HelloWorld()
        {
            return _userRepository.HelloWorld();
        }

        public async Task<ResponseResult> Login(LoginInfoModel loginInfo)
        {
            //todo: 处理验证码


            var userInfo = _userRepository.GetList(u => u.UserName.Equals(loginInfo.UserName) && u.Status.Equals(StatusEnum.Yes)).FirstOrDefault();
            if (userInfo == null)
            {
                return new ResponseResult(false, "用户不存在");
            }
            if (!loginInfo.UserPwd.ToMD5String().Equals(userInfo.Password))
            {
                return new ResponseResult(false, "密码错误");
            }
            //更新认证信息并返回登录结果
            var resultModel = await UpdateAuthInfo(userInfo, loginInfo);
            if (resultModel != null)
            {
                return resultModel;
            }
            return new ResponseResult(false, "更新认证信息失败");

        }


        public async Task<ResponseResult> RefreshToken(string refreshToken)
        {
            var cacheKey = $"{GlobalSettings.LyAdminOptions.DefaultAppKeys.AuthRefreshToken}:{refreshToken}";
            var authInfo = CacheHelper.Cache.GetCache<AuthResource>(cacheKey);
            if (authInfo == null)
            {
                var sysAuthInfo = _authRepository.GetList(a => a.RefreshToken.Equals(refreshToken)).FirstOrDefault();
                if (sysAuthInfo == null)
                {
                    return await Task.FromResult(new ResponseResult(false, "身份认证信息无效，请重新登录"));
                }
                authInfo = _mapper.Map<AuthResource>(sysAuthInfo);
                //加入缓存
                var expires = (int)(authInfo.RefreshTokenExpiredTime - DateTime.Now).TotalMinutes;
                CacheHelper.Cache.SetCache(cacheKey, authInfo, TimeSpan.FromMinutes(expires));
            }
            if (authInfo.RefreshTokenExpiredTime <= DateTime.Now)
            {
                return await Task.FromResult(new ResponseResult(false, "身份认证信息过期，请重新登录"));
            }
            var userInfo = _userRepository.GetList(u => u.Id.Equals(authInfo.UserId)).FirstOrDefault();
            if (userInfo == null)
            {
                return await Task.FromResult(new ResponseResult(false, "账户信息不存在"));
            }
            if (userInfo.Status == StatusEnum.No)
            {
                return await Task.FromResult(new ResponseResult(false, "账户状态已禁用"));
            }

            var userInfoResource = _mapper.Map<UserInfoResource>(userInfo);

            return await Task.FromResult(new ResponseResult<LoginResultModel>(true, new LoginResultModel
            {
                UserInfo = userInfoResource,
                AuthResource = authInfo
            }));
        }

        public async Task<ResponseResult> GetAuthInfo(long accountId, int platform)
        {
            var cacheKey = $"{GlobalSettings.LyAdminOptions.DefaultAppKeys.AuthInfo}:{accountId}:{platform}";
            var authInfo = CacheHelper.Cache.GetCache<AuthResource>(cacheKey);
            if (authInfo == null)
            {
                var platformValue = (PlatformEnum)platform;
                var sysAuthInfo = _authRepository.GetList(a => a.UserId.Equals(accountId) && a.Platform.Equals(platformValue)).FirstOrDefault();
                if (sysAuthInfo == null)
                {
                    return await Task.FromResult(new ResponseResult(false, "身份认证信息无效，请重新登录"));
                }
                authInfo = _mapper.Map<AuthResource>(sysAuthInfo);
                //加入缓存
                var expires = (int)(authInfo.RefreshTokenExpiredTime - DateTime.Now).TotalMinutes;
                CacheHelper.Cache.SetCache(cacheKey, authInfo, TimeSpan.FromMinutes(expires));
            }
            if (authInfo.RefreshTokenExpiredTime <= DateTime.Now)
            {
                return await Task.FromResult(new ResponseResult(false, "身份认证信息过期，请重新登录"));
            }
            var userInfo = _userRepository.GetList(u => u.Id.Equals(authInfo.UserId)).FirstOrDefault();
            if (userInfo == null)
            {
                return await Task.FromResult(new ResponseResult(false, "账户信息不存在"));
            }
            if (userInfo.Status == StatusEnum.No)
            {
                return await Task.FromResult(new ResponseResult(false, "账户状态已禁用"));
            }

            var userInfoResource = _mapper.Map<UserInfoResource>(userInfo);

            return await Task.FromResult(new ResponseResult<LoginResultModel>(true, new LoginResultModel
            {
                UserInfo = userInfoResource,
                AuthResource = authInfo
            }));
        }

        /// <summary>
        /// 更新账户认证信息
        /// </summary>
        private async Task<ResponseResult> UpdateAuthInfo(SysUser userInfo, LoginInfoModel loginInfo)
        {
            var authInfo = new SysAuth
            {
                UserId = userInfo.Id,
                Platform = loginInfo.Platform,
                LoginTime = DateTime.Now,
                LoginIP = loginInfo.IP ?? "1",
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpiredTime = DateTime.Now.AddDays(7)//默认刷新令牌有效期7天
            };
            var platform = Convert.ToInt32(loginInfo.Platform);
            var entity = _authRepository.GetList(a => a.UserId == userInfo.Id && a.Platform == loginInfo.Platform).FirstOrDefault();
            if (entity != null)
            {
                entity.UserId = userInfo.Id;
                entity.Platform = loginInfo.Platform;
                entity.LoginTime = DateTime.Now;
                entity.LoginIP = loginInfo.IP ?? "1";
                entity.RefreshToken = GenerateRefreshToken();
                entity.RefreshTokenExpiredTime = DateTime.Now.AddDays(7);//默认刷新令牌有效期7天

                _authRepository.Update(entity);
            }
            else
            {
                _authRepository.Insert(authInfo);
            }
            var count = await _iUnitOfWork.SaveChangesAsync();


            if (count.Equals(1))
            {
                //删除验证码缓存
                if (loginInfo.VerifyCode != null)
                {
                    CacheHelper.Cache.RemoveCache($"{GlobalSettings.LyAdminOptions.DefaultAppKeys.VerifyCode}:{loginInfo.VerifyCode.Id}");
                }

                //删除认证信息缓存
                CacheHelper.Cache.RemoveCache($"{GlobalSettings.LyAdminOptions.DefaultAppKeys.AuthInfo}:{userInfo.Id}:{loginInfo.Platform}");


                var userInfoResource = _mapper.Map<UserInfoResource>(userInfo);
                var authInfoResource = _mapper.Map<AuthResource>(authInfo);

                return new ResponseResult<LoginResultModel>(true, new LoginResultModel
                {
                    UserInfo = userInfoResource,
                    AuthResource = authInfoResource
                });
            }
            return null;
        }

        /// <summary>
        /// 生成刷新令牌
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

    }
}