using AutoMapper;
using Ly.Admin.Model;
using Ly.Admin.Resources;
using Ly.Admin.Util.Enum;

namespace Ly.Admin.Core.AutoMapper
{
    public class PermissionMenuProfile : Profile, IProfile
    {
        public PermissionMenuProfile()
        {
            CreateMap<SysMenu, PermissionMenuResource>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.MenuName))
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.MenuIcon))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.MenuType.Equals(MenuTypeEnum.Directory) ? "0" : "1"))
                .ForMember(dest => dest.OpenType,
                    opt => opt.MapFrom(src => src.OpenType.Equals(MenuOpenTypeEnum.Blank) ? "_blank" : "_iframe"))
                .ForMember(dest => dest.Href, opt => opt.MapFrom(src => src.MenuUrl));

        }
    }
}