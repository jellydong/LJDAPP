using Ly.Admin.Model;
using Ly.Admin.Resources;
using Ly.Admin.Util.Model;
using System.Threading.Tasks;

namespace Ly.Admin.IServices
{
    public interface IUserService:IBaseService<SysUser>
    {
        string HelloWorld();
        Task<ResponseResult> Login(LoginInfoModel loginInfo);
        Task<ResponseResult> CreateVerifyCode(int length);
        Task<ResponseResult> RefreshToken(string refreshToken);
        Task<ResponseResult> GetAuthInfo(long accountId, int platform);
    }
}