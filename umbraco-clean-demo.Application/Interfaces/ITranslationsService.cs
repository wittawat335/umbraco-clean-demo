
namespace umbraco_clean_demo.Application.Interfaces;

public interface ITranslationsService
{
	Task<Response<string>> MigrateTranslations(string connectionString);
}
