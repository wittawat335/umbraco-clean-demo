using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IUserGroupRepository
{
	Task<List<Roles>> GetRoles(string connectionString);
	Task<bool> InsertUserGroup(List<umbracoUserGroup> model);
}
