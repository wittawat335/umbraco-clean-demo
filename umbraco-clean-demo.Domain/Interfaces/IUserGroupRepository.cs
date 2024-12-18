using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IUserGroupRepository
{
	Task<List<Role>> GetRoles(string connectionString);
	Task<bool> InsertUserGroup(List<umbracoUserGroup> model);
}
