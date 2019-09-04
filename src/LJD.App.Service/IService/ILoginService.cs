using System.IO;
using LJD.App.Model.ViewModels;
using LJD.App.Service.IService;

namespace LJD.App.Service.IService
{
    public interface ILoginService
    {
        ResponseResult Login(LoginInfo loginInfo);

        byte[] GetVcode();
    }
}