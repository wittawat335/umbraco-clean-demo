using Microsoft.Extensions.DependencyInjection;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Application.MappingProfiles;
using umbraco_clean_demo.Application.Services;
using AutoMapper;

namespace umbraco_clean_demo.Application;

public static class DependencyInjection
{
	public static IServiceCollection InjectServices(this IServiceCollection services)
	{
		var config = new MapperConfiguration(_ =>
		{
			_.AddProfile(typeof(MappingProfile));
		});

		var mapper = config.CreateMapper();
		services.AddSingleton(mapper);

		services.AddScoped<IPageTypeService, PageTypeService>();
		services.AddScoped<ITranslationsService, TranslationsService>();
		services.AddScoped<IUserRoleService, UserRoleService>();

		return services;
	}
}
