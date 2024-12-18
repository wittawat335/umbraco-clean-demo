using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Interfaces;

public interface IUserRoleService
{
	Task<Response<string>> MigrateUsers(MigrateModel model);
	Task<Response<string>> MigrateRoles(MigrateModel model);
}
