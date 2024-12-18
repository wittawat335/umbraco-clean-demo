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

	public async Task<bool> InsertRoles(List<UserRoleModel> model)
	{
		const string insertSql = @"
        INSERT INTO umbracoUserGroup (userGroupAlias, userGroupName, userGroupDefaultPermissions)
        VALUES (@Alias, @Name, @DefaultPermissions);";

		using (var connection = _context.CreateConnection())
		{
			connection.Open();

			var tasks = model.Take(1).GroupBy(r => r.RoleName).Select(async item =>
			{
				// ตรวจสอบว่ามี Role นี้ในฐานข้อมูลหรือยัง
				var exists = await connection.ExecuteScalarAsync<int>(
					"SELECT COUNT(1) FROM umbracoUserGroup WHERE userGroupName = @Name",
					new { Name = item.Key });

				// เพิ่ม Role ใหม่ถ้ายังไม่มี
				if (exists == 0)
				{
					await connection.ExecuteAsync(insertSql, new
					{
						Alias = item.Key.ToLower().Replace(" ", "_"),
						Name = item.Key,
						DefaultPermissions = ""
					});
				}
			});

			await Task.WhenAll(tasks); // รัน Tasks พร้อมกัน
		}

		return true;
	}

	private IDbConnection Connection(string connectionString) => new SqlConnection(connectionString);
}
