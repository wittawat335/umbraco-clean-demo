using System.Data.SqlClient;
using System.Data;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;
using Dapper;

namespace umbraco_clean_demo.Infrastructure.Repositories;

public class UserGroupRepository(IGenericRepository<Role> _repository, DapperContext _context) : IUserGroupRepository
{
	public async Task<List<Role>> GetRoles(string connectionString) 
		=> await _repository.GetAllAsync("CMS_Role", connectionString);

	public async Task<bool> InsertUserGroup(List<umbracoUserGroup> model)
	{
		const string insertSql = @"
        INSERT INTO umbracoUserGroup (userGroupAlias, userGroupName, createDate, updateDate, hasAccessToAllLanguages)
        VALUES (@userGroupAlias, @userGroupName, @createDate, @updateDate, @hasAccessToAllLanguages);";

		const string checkSql = "SELECT COUNT(1) FROM umbracoUserGroup WHERE userGroupName = @Name";

		using (var connection = _context.CreateConnection())
		{
			connection.Open();

			var tasks = model.Take(1).GroupBy(r => r.userGroupName).Select(async item =>
			{
				// ตรวจสอบว่ามี Role นี้ในฐานข้อมูลหรือยัง
				var exists = await connection.ExecuteScalarAsync<int>(checkSql, new { Name = item.Key });

				// เพิ่ม Role ใหม่ถ้ายังไม่มี
				if (exists == 0)
				{
					await connection.ExecuteAsync(insertSql, item.Select(_ => new
					{
						_.userGroupAlias,
						_.userGroupName,
						_.createDate,
						_.updateDate,
						_.hasAccessToAllLanguages
					}));
				}
			});

			await Task.WhenAll(tasks); // รัน Tasks พร้อมกัน
		}

		return true;
	}
}
