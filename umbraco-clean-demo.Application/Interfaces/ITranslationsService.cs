
using umbraco_clean_demo.Domain.Entities.Kentico;

namespace umbraco_clean_demo.Application.Interfaces;

public interface ITranslationsService
{
	Task<Response<string>> MigrateTranslations(string connectionString);
}
