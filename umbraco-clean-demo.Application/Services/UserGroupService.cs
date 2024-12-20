using AutoMapper;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class UserGroupService(IUserGroupRepository _repository, IMapper _mapper) : IUserGroupService
{
	public async Task<Response<string>> MigrateUserGroup(MigrateModel model)
	{
		var response = new Response<string>();
		var list = await _repository.GetRoles(model);
		if(list.Count > 0)
		{
			response.isSuccess = await _repository.InsertUserGroup(_mapper.Map<List<umbracoUserGroup>>(list));
		}

		if (response.isSuccess) response.message = Constants.Message.MigrationSuccess;

		return response;
	}
}
