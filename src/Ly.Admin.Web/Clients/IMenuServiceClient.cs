using Ly.Admin.Resources;
using Ly.Admin.Util.Model;
using Refit;

namespace Ly.Admin.Web.Clients
{
    public interface IMenuServiceClient
    {
        [Get("/Menu/GetById")]
        Task<ResponseResult<MenuResource>> GetById(int id, int? parentId);

        [Get("/Menu/GetParentTree")]

        Task<ResponseResult<List<MenuResource>>> GetParentTree();
    }
}
