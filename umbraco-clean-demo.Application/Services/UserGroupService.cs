﻿using AutoMapper;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class UserGroupService(IUserGroupRepository _repository, IMapper _mapper) : IUserGroupService
{
	Commons cm = new Commons();
	public async Task<Response<string>> MigrateUserGroup(MigrateModel model)
	{
		var response = new Response<string>();
		var list = await _repository.GetRoles(cm.GetConnectionString(model));
		if(list.Count > 0)
		{
			var userGroup = _mapper.Map<List<umbracoUserGroup>>(list);
			response.isSuccess = await _repository.InsertUserGroup(userGroup);
		}

		if (response.isSuccess) response.message = Constants.Message.MigrationSuccess;

		return response;
	}
}
