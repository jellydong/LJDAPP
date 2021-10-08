using AutoMapper;
using Ly.Admin.Model;
using Ly.Admin.Resources;

namespace Ly.Admin.Core.AutoMapper
{
    public class PostProfile : Profile, IProfile
    {
        public PostProfile()
        {
            CreateMap<Post, PostResource>()
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.UpdatedTime.HasValue ? src.CreatedTime : src.UpdatedTime));
            CreateMap<PostResource, Post>();
        }
    }
}