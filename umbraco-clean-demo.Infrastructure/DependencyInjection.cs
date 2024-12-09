﻿using Microsoft.Extensions.DependencyInjection;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;
using umbraco_clean_demo.Infrastructure.Repositories;

namespace umbraco_clean_demo.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection InjectInfra(this IServiceCollection services)
	{
		services.AddSingleton<DapperContext>();
		services.AddScoped<IMigrateRepository, MigrateRepository>();
		return services;
	}
}
