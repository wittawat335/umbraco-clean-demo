using System.Data.SqlClient;
using System.Data;
using Dapper;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Infrastructure.Repositories;
public class MediaRepository<T>(DapperContext _context) : IMediasRepository<T> where T : class
{
	Commons cm = new Commons();
	
	public Task<int> DeleteAsync(object id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<T>> GetAllAsync(string tableName, MigrateModel model)
	{
		using (var dbConnection = Connection(cm.GetConnectionString(model)))
		{
			var result = await dbConnection.QueryAsync<T>($"SELECT * FROM {tableName}");
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

	public async Task MigrateMediaTest()
	{
		using (var connection = _context.CreateConnection())
		{
			const string query = @"
                SELECT 
                    [id] AS Id,
                    [languageISOCode] AS LanguageISOCode,
                    [languageCultureName] AS LanguageCultureName,
                    [isDefaultVariantLang] AS IsDefaultVariantLang,
                    [mandatory] AS Mandatory,
                    [fallbackLanguageId] AS FallbackLanguageId
                FROM [umbraco-clean-db].[dbo].[umbracoLanguage]";

			var model = await connection.QueryAsync<UmbracoLanguage>(query);
		}
	}

	public Task<int> UpdateAsync(T entity)
	{
		throw new NotImplementedException();
	}

	private IDbConnection Connection(string connectionString) => new SqlConnection(connectionString);
}
