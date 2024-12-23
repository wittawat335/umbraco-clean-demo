using AutoMapper;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Persistence.Dtos;
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
		var umbracoUser = _mapper.Map<List<UserDto>>(users);
		foreach (var item in umbracoUser)
		{
			if (_service.GetByUsername(item.UserName) == null)
			{
				if (string.IsNullOrWhiteSpace(item.Email)) item.Email = "default_email@example.com";

				var user = _service.CreateUserWithIdentity(item.UserName, item.Email);
				user.CreateDate = item.CreateDate;
				user.UpdateDate = item.UpdateDate;
				user.LastLoginDate = item.LastLoginDate ;
				user.Language = string.IsNullOrWhiteSpace(item.UserLanguage) ? "en-US" : item.UserLanguage;
				user.IsApproved = item.Disabled;

				_service.Save(user);
			}
		}

		response.isSuccess = true;
		response.message = Constants.Message.MigrationSuccess;

		return response;
	}
}
