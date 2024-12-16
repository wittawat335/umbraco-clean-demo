using System.ComponentModel.Design;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Application.MappingProfiles;
using umbraco_clean_demo.Application.Services;
using umbraco_clean_demo.Infrastructure.DBContext;

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
		//services.AddSingleton<IDictionaryService, DictionaryService>();
		services.AddScoped<ITranslationsService, TranslationsService>();
		//services.AddScoped<IUserService, UserService>();
		//services.AddScoped<IEmployeeService, EmployeeService>();
		//services.AddScoped<IRoleService, RoleService>();
		//services.AddScoped<IDepartmentService, DepartmentService>();
		//services.AddScoped<ITestService, TestService>();
		return services;
	}
}
