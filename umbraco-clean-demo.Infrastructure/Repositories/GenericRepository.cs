using System.Data.SqlClient;
using System.Data;
using umbraco_clean_demo.Domain.Interfaces;
using Dapper;
namespace umbraco_clean_demo.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

	public GenericRepository()
	{
		
	}
	private IDbConnection Connection(string connectionString) => new SqlConnection(connectionString);
	public async Task<List<T>> GetAllAsync(string tableName, string connectionString)
	{
		using (var dbConnection = Connection(connectionString))
		{
			var query = $"SELECT * FROM {tableName}";
			var result = await dbConnection.QueryAsync<T>(query);

			return result.ToList();
		}
	}

	public Task<T> GetByIdAsync(object id)
	{
		throw new NotImplementedException();
	}

	public Task<int> InsertAsync(T entity)
	{
		throw new NotImplementedException();
	}

	public Task<int> UpdateAsync(T entity)
	{
		throw new NotImplementedException();
	}

	public Task<int> DeleteAsync(object id)
	{
		throw new NotImplementedException();
	}
}
