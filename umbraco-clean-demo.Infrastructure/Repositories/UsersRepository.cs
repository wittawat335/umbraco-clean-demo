using System.Data.SqlClient;
using System.Data;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using Dapper;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
	public UsersRepository()
	{

	}
	private IDbConnection Connection(string connectionString) => new SqlConnection(connectionString);
	public async Task<List<UserRoleModel>> GetUserRoles(string connectionString)
	{
		using (var dbConnection = Connection(connectionString))
		{
			var result = await dbConnection.QueryAsync<UserRoleModel>(Constants.SQLCommand.GetUserRoles);

			return result.ToList();
		}
	}
}
