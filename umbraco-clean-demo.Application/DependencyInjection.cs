using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using umbraco_clean_demo.Application.MappingProfiles;

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
		//services.AddScoped<IAuthenticateService, AuthenticateService>();
		//services.AddScoped<IUserService, UserService>();
		//services.AddScoped<IEmployeeService, EmployeeService>();
		//services.AddScoped<IRoleService, RoleService>();
		//services.AddScoped<IDepartmentService, DepartmentService>();
		//services.AddScoped<ITestService, TestService>();
		return services;
	}
}
