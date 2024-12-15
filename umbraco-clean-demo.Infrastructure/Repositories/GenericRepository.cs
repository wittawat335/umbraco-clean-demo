using System.Data.SqlClient;
using System.Data;
using umbraco_clean_demo.Domain.Interfaces;
using Dapper;
namespace umbraco_clean_demo.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly string _connectionString;
	private readonly string _tableName;

	public GenericRepository(string connectionString, string tableName)
	{
		_connectionString = connectionString;
		_tableName = tableName;
	}
	private IDbConnection Connection => new SqlConnection(_connectionString);
	public async Task<List<T>> GetAllAsync()
	{
		using (var dbConnection = Connection)
		{
			var query = $"SELECT * FROM {_tableName}";
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
