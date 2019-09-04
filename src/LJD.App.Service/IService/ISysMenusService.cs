using LJD.App.Model.DbModels;

namespace LJD.App.Service.IService
{
    public partial interface ISysMenusService : IBaseService<SysMenus>
    {
        ResponseResult Delete(string id);
    }
}