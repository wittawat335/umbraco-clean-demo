using System.Data.SqlClient;
using System.Data;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using Dapper;
using umbraco_clean_demo.Infrastructure.Utilities;
using umbraco_clean_demo.Infrastructure.DBContext;

namespace umbraco_clean_demo.Infrastructure.Repositories;

public class UsersRepository(IGenericRepository<UserRoleModel> _repository, DapperContext _context) : IUsersRepository
{
	public async Task<List<UserRoleModel>> GetUserRoles(string connectionString)
	{
		using (var dbConnection = Connection(connectionString))
		{
			var result = await dbConnection.QueryAsync<UserRoleModel>(Constants.SQLCommand.GetUserRoles);

			return result.ToList();
		}
	}

	public async Task<List<UserRoleModel>> GetUserRolesFromView(string connectionString) 
		=> await _repository.GetAllAsync(Constants.K_Table.UserSettingsRole, connectionString);

	public Task<List<UserRoleModel>> InsertRoles(List<UserRoleModel> model, string connectionString)
	{
		throw new NotImplementedException();
	}




	private IDbConnection Connection(string connectionString) => new SqlConnection(connectionString);
}
