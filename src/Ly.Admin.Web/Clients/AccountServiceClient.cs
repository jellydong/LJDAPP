using Ly.Admin.Resources;
using Ly.Admin.Util.Model;

namespace Ly.Admin.Web.Clients
{
    public class AccountServiceClient : LyAdminApiBaseServiceClient
    {
        public AccountServiceClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<ResponseResult<List<PermissionMenuResource>>> PermissionMenu()
        {
            return await GetObjectAsync<ResponseResult<List<PermissionMenuResource>>>("/Account/PermissionMenu");
        }
    }
}
