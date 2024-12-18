using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;

namespace umbraco_clean_demo.Infrastructure.Repositories;

public class UserGroupRepository(IGenericRepository<Role> _repository, DapperContext _context) : IUserGroupRepository
{
	public async Task<List<Role>> GetRoles(string connectionString) 
		=> await _repository.GetAllAsync("CMS_Role", connectionString);

	public async Task<bool> InsertUserGroup(List<umbracoUserGroup> model)
	{
		throw new NotImplementedException();
	}
}
