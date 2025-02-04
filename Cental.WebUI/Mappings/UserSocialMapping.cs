using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Cental.WebUI.Mappings
{
    public class UserSocialMapping : Profile
    {
        protected UserSocialMapping()
        {
            CreateMap<UserSocial , ResultUserSocialDto>().ReverseMap();
            CreateMap<UserSocial , CreateUserSocialDto>().ReverseMap();
            CreateMap<UserSocial , UpdateUserSocialDto>().ReverseMap();
        }
    }
}
