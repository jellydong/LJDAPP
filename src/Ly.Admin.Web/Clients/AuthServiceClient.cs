using Ly.Admin.Auth;
using Ly.Admin.Resources;
using Ly.Admin.Util.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Ly.Admin.Web.Clients
{
    public class AuthServiceClient : LyAdminApiBaseServiceClient
    {
        public AuthServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }


        public async Task<ResponseResult<VerifyCodeModel>> VerifyCode()
        {
            return await GetObjectAsync<ResponseResult<VerifyCodeModel>>("/Auth/VerifyCode");
        }

        public async Task<ResponseResult<JwtTokenModel>> Login(LoginInfoModel loginInfo)
        {
            return await PostObjectAsync<ResponseResult<JwtTokenModel>, LoginInfoModel>("/Auth/Login", loginInfo); 
        }
    }
}
