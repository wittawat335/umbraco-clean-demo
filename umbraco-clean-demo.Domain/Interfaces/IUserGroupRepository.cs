using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IUserGroupRepository
{
	Task<List<Roles>> GetRoles(MigrateModel model);
	Task<bool> InsertUserGroup(List<umbracoUserGroup> model);
}
