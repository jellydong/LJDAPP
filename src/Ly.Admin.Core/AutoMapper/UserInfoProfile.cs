using AutoMapper;
using Ly.Admin.Model;
using Ly.Admin.Resources;

namespace Ly.Admin.Core.AutoMapper
{
    public class UserInfoProfile: Profile, IProfile
    {
        public UserInfoProfile()
        {
            //这个只要实体类到Resources就行
            CreateMap<SysUser, UserInfoResource>();
        }
    }
}