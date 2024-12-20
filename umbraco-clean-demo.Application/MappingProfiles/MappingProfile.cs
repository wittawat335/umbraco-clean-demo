using AutoMapper;
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

		CreateMap<Users, umbracoUser>()
			.ForMember(dest => dest.userDisabled, opt => opt.MapFrom(src => src.UserEnabled))
			.ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.UserName))
			.ForMember(dest => dest.userLogin, opt => opt.MapFrom(src => src.UserName))
			.ForMember(dest => dest.userEmail, opt => opt.MapFrom(src => src.Email))
			.ForMember(dest => dest.userLanguage, opt => opt.MapFrom(src => src.PreferredUICultureCode))
			.ForMember(dest => dest.lastLoginDate, opt => opt.MapFrom(src => src.LastLogon))
			.ForMember(dest => dest.createDate, opt => opt.MapFrom(src => src.UserCreated))
			.ForMember(dest => dest.updateDate, opt => opt.MapFrom(src => src.UserLastModified));
	}
}
