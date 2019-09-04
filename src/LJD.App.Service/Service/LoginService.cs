using System;
using System.Linq.Dynamic.Core;
using LJD.App.Model.DbModels;
using LJD.App.Model.ViewModels;
using LJD.App.Repository.IRepository;
using LJD.App.Service.IService;
using LJD.App.Util;

namespace LJD.App.Service.Service
{
    public partial class LoginService : ILoginService
    {
        private readonly ISysUserInfoRepository _sysUserInfoRepository;

        public LoginService(ISysUserInfoRepository sysUserInfoRepository)
        {
            _sysUserInfoRepository = sysUserInfoRepository;
        }

        public byte[] GetVcode()
        {
            string strCode = ValidateCodeHelper.CreateValidateCode(4);
            //验证码放到Session里面去
            SessionHelper.Session[APPKeys.Vercode] = strCode;

            byte[] imgBytes = ValidateCodeHelper.CreateValidateGraphic(strCode);
            return imgBytes;
        }

        public ResponseResult Login(LoginInfo loginInfo)
        {
            ResponseResult responseResult = new ResponseResult(false, "未执行！");
            try
            {
                //第一步：处理验证码
                string sessionVerCode = SessionHelper.Session[APPKeys.Vercode].ToString();

                //取完后要删除，不然Session里还有
                SessionHelper.Session[APPKeys.Vercode] = string.Empty;
                if (string.IsNullOrWhiteSpace(sessionVerCode) || !sessionVerCode.Equals(loginInfo.Vercode))
                {
                   throw new Exception("验证码错误!");
                }

                //第二部：处理验证用户名密码

                //lambda表达式不能进行强制类型转换
                int status = (int)Status.On;
                SysUserInfo user = _sysUserInfoRepository.GetList(u =>
                        u.ULoginName.Equals(loginInfo.ULoginName) && u.Status == status)
                    .FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("用户不存在或已被禁用!");
                }

                var aa = loginInfo.ULoginPwd.ToMD5String();
                if (!loginInfo.ULoginPwd.ToMD5String().Equals(user.ULoginPWD))
                {
                    throw new Exception("密码错误!");
                }
                //登陆
                CurrentUserManage.Login(user);
                responseResult.Message = "登陆成功！";
                responseResult.Success = true;
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message; 
            }

            return responseResult;
        }
    }
}