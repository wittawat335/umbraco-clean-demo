using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class UsersService : IUsersService
{
	private readonly IUsersRepository _userRepository;
	private readonly IUserService _userService;
	Commons cm = new Commons();

	public UsersService(IUsersRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Response<string>> MigrateUsers(MigrateModel model)
	{
		var response = new Response<string>();
		var users = await _userRepository.GetUserRoles(cm.GetConnectionString(model));

		foreach (var u in users.Take(1).GroupBy(u => u.UserID))
		{
			if (_userService.GetByUsername(u.First().UserName) == null)
			{
				var user = _userService.CreateUserWithIdentity(
					u.First().UserName,
					u.First().Email);

				_userService.Save(user);
			}
		}

		return response;
	}
}
