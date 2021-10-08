using AutoMapper;
using Ly.Admin.Model;
using Ly.Admin.Resources;

namespace Ly.Admin.Core.AutoMapper
{
    public class MenuProfile:Profile,IProfile
    {
        public MenuProfile()
        {
            CreateMap<SysMenu, MenuResource>()
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.UpdatedTime.HasValue ? src.CreatedTime : src.UpdatedTime))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MenuName)) 
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.MenuIcon))
                ;

            CreateMap<MenuResource, SysMenu>()
                .ForMember(dest => dest.MenuName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MenuIcon, opt => opt.MapFrom(src => src.Icon))
                ;
        }
    }
}