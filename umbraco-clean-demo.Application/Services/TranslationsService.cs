using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;

namespace umbraco_clean_demo.Application.Services;

public class TranslationsService : ITranslationsService
{
	private readonly IGenericRepository<LocalizationModel> _repository;
	public Task<Response<string>> MigrateTranslations(string connectionString)
	{
		throw new NotImplementedException();
	}
}
