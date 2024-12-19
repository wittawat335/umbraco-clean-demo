using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Interfaces;

public interface IUsersService
{
	Task<Response<string>> MigrateUsers(MigrateModel model);
}
