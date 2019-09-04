using System;
using System.Linq;
using System.Linq.Expressions;
using LJD.App.Model.DbModels;
using LJD.App.Repository.IRepository;
using LJD.App.Repository.IUnitOfWork;
using LJD.App.Service.IService;

namespace LJD.App.Service.Service
{
    /// <summary>
    /// 用户表
    /// </summary>        
    public partial class SysUserInfoService : BaseService<SysUserInfo>, ISysUserInfoService
    { 
    }
}