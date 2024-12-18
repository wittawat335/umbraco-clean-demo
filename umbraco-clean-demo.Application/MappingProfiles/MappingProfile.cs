using AutoMapper;
using umbraco_clean_demo.Domain.Entities;
namespace umbraco_clean_demo.Application.MappingProfiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		// Map Role -> umbracoUserGroup
		CreateMap<Role, umbracoUserGroup>()
			//.ForMember(dest => dest.id, opt => opt.MapFrom(src => src.RoleID))
			.ForMember(dest => dest.userGroupAlias, opt => opt.MapFrom(src => src.RoleName.ToLower().Replace(" ", "_")))
			.ForMember(dest => dest.userGroupName, opt => opt.MapFrom(src => src.RoleName))
			.ForMember(dest => dest.createDate, opt => opt.MapFrom(src => src.RoleLastModified))
			.ForMember(dest => dest.updateDate, opt => opt.MapFrom(src => src.RoleLastModified))
			.ForMember(dest => dest.hasAccessToAllLanguages, opt => opt.MapFrom(src => true));
			//.ForMember(dest => dest.startContentId, opt => opt.MapFrom(src => src.RoleGroupID))
			//.ForMember(dest => dest.startMediaId, opt => opt.MapFrom(src => src.RoleIsDomain));
	}
}
