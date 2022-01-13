using Ly.Admin.Auth;
using Ly.Admin.Resources;
using Ly.Admin.Util.Model;
using Refit;

namespace Ly.Admin.Web.Clients
{
    public interface IAuthServiceClient
    {
        [Get("/Auth/VerifyCode")]
        Task<ResponseResult<VerifyCodeModel>> VerifyCode();

        [Post("/Auth/Login")]
        Task<ResponseResult<JwtTokenModel>> Login(LoginInfoModel loginInfo);
    }
}
