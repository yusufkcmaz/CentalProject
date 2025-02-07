using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Cental.WebUI.Mappings
{
    public class UserSocialMapping : Profile
    {
        public UserSocialMapping()
        {
            CreateMap<UserSocial, ResultUserSocialDto>().ForMember(dest =>                                                            dest.SocialMediaUrl, o =>
                                                       o.MapFrom(src => src.Url));
            CreateMap<UserSocial, CreateUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, UpdateUserSocialDto>().ReverseMap();
        }
    }
}
