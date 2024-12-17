
using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IUsersRepository
{
	Task<List<UserRoleModel>> GetUserRoles(string connectionString);
}
