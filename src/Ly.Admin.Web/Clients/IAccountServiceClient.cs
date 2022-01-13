using Ly.Admin.Resources;
using Ly.Admin.Util.Model;
using Refit;

namespace Ly.Admin.Web.Clients
{
    public interface IAccountServiceClient
    {
        [Get("/Account/PermissionMenu")]
        Task<ResponseResult<List<PermissionMenuResource>>> PermissionMenu();
    }
}
