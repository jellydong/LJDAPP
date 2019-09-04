using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IRepository;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service.IService;
using LJD.App.Util;
using Microsoft.EntityFrameworkCore;

namespace LJD.App.Service.Service
{
    public partial class SysMenusService : BaseService<SysMenus>, ISysMenusService
    {
        private readonly ISysMenusRepository _iSysMenusRepository;
        private readonly ISysFunctionRepository _sysFunctionRepository; 

        public SysMenusService(ISysMenusRepository iSysMenusRepository, IUnitOfWork unitOfWork,ISysFunctionRepository sysFunctionRepository) : base(iSysMenusRepository)
        {
            _unitOfWork = unitOfWork;
            _iSysMenusRepository = iSysMenusRepository;
            _sysFunctionRepository = sysFunctionRepository;
        }
        public ResponseResult Delete(string id)
        {
            ResponseResult responseResult = new ResponseResult(false, "删除失败，未知错误！");
            //判断是不是存在子菜单
            var children = GetList(m => m.ParentID.Equals(id)).Count();
            if (children != 0)
            {
                responseResult.Message = "存在下级菜单,不可删除！";
            }
            else
            {
                //删除下面的按钮
                _sysFunctionRepository.Delete(f => f.ParentID.Equals(id));
                //删除本身
                Delete(m => m.ObjectID.Equals(id));
                _unitOfWork.SaveChanges();
                responseResult.Success = true;
                responseResult.Message = "删除成功！";
            }

            return responseResult;
        }
    }
}