using AutoMapper;
using Umbraco.Cms.Infrastructure.Persistence.Dtos;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;
namespace umbraco_clean_demo.Application.MappingProfiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		// Map Role -> umbracoUserGroup
		CreateMap<Roles, umbracoUserGroup>()
			.ForMember(dest => dest.userGroupAlias, opt => opt.MapFrom(src => src.RoleName.ToLower().Replace(" ", "_")))
			.ForMember(dest => dest.userGroupName, opt => opt.MapFrom(src => src.RoleName))
			.ForMember(dest => dest.createDate, opt => opt.MapFrom(src => src.RoleLastModified))
			.ForMember(dest => dest.updateDate, opt => opt.MapFrom(src => src.RoleLastModified))
			.ForMember(dest => dest.hasAccessToAllLanguages, opt => opt.MapFrom(src => true));

		CreateMap<Users, UserDto>()
			.ForMember(dest => dest.Disabled, opt => opt.MapFrom(src => src.UserEnabled))
			.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
			.ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.UserLanguage, opt => opt.MapFrom(src => src.PreferredUICultureCode))
			.ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLogon))
			.ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.UserCreated))
			.ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UserLastModified));
	}
}
