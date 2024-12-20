using AutoMapper;
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class UsersService(IMigrateRepository<Users> _repository, IUserService _service, IMapper _mapper) : IUsersService
{
	public async Task<Response<string>> MigrateUsers(MigrateModel model)
	{
		var response = new Response<string>();
		var users = await _repository.GetAllAsync(Constants.K_Table.Users, model);
		var umbracoUser = _mapper.Map<List<umbracoUser>>(users);
		foreach (var item in umbracoUser)
		{
			if (_service.GetByUsername(item.userName) == null)
			{
				var user = _service.CreateUserWithIdentity(item.userName, item.userEmail);
				_service.Save(user);
			}
		}

		response.isSuccess = true;
		response.message = Constants.Message.MigrationSuccess;

		return response;
	}
}
