using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Interfaces;

public interface IUserGroupService
{
	Task<Response<string>> MigrateUserGroup(MigrateModel model);
}
