﻿using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class UserRoleService(IUsersRepository _repository, IUserService _service) : IUserRoleService
{
	public async Task<Response<string>> MigrateUsers(MigrateModel model)
	{
		var response = new Response<string>();
		var users = await _repository.GetUserRoles(model);
		foreach (var item in users.Take(10).GroupBy(u => u.UserID))
		{
			if (_service.GetByUsername(item.First().UserName) == null)
			{
				var user = _service.CreateUserWithIdentity(item.First().UserName, item.First().Email);
				_service.Save(user);
			}
		}

		response.isSuccess = true;
		response.message = Constants.Message.MigrationSuccess;

		return response;
	}
}
