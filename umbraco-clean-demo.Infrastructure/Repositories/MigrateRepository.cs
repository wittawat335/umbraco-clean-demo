using Dapper;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.DBContext;

namespace umbraco_clean_demo.Infrastructure.Repositories;
public class MigrateRepository : IMigrateRepository
{
	private readonly DapperContext _context;

	public MigrateRepository(DapperContext context)
	{
		_context = context;
	}

	public async Task MigrateTest()
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
}
