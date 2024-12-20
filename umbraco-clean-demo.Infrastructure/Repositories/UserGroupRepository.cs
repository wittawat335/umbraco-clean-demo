using System.Data;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;
using Dapper;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Infrastructure.Repositories;

public class UserGroupRepository(IMigrateRepository<Roles> _repository, DapperContext _context) : IUserGroupRepository
{
	public async Task<List<Roles>> GetRoles(MigrateModel model) 
		=> await _repository.GetAllAsync("CMS_Role", model);

	public async Task<bool> InsertUserGroup(List<umbracoUserGroup> model)
	{
		using var connection = _context.CreateConnection();
		connection.Open();

		foreach (var item in model)
		{
			await connection.ExecuteAsync(
				"SP_INSERT_USER_GROUP",
				new
				{
					item.userGroupAlias,
					item.userGroupName,
					item.createDate,
					item.updateDate,
					item.hasAccessToAllLanguages
				},
				commandType: CommandType.StoredProcedure
			);
		}

		return true;
	}
}
