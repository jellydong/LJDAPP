using AutoMapper;
using Ly.Admin.Model;
using Ly.Admin.Resources;

namespace Ly.Admin.Core.AutoMapper
{
    public class AuthProfile : Profile, IProfile
    {
        public AuthProfile()
        {
            CreateMap<SysAuth, AuthResource>()
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.UpdatedTime.HasValue ? src.CreatedTime : src.UpdatedTime));
            CreateMap<AuthResource, SysAuth>();
        }
    }
}
