using umbraco_clean_demo.Domain.Entities;
namespace umbraco_clean_demo.Application.Interfaces;

public interface ITranslationsService
{
	Task<Response<string>> MigrateTranslations(MigrateModel model);
}
