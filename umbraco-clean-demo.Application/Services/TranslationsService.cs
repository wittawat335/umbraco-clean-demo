using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class TranslationsService : ITranslationsService
{
	private readonly IGenericRepository<LocalizationModel> _repository;
	private readonly ILocalizationService _localizationService;
	Commons cm = new Commons();

	public TranslationsService(IGenericRepository<LocalizationModel> repository, ILocalizationService localizationService)
	{
		_repository = repository;
		_localizationService = localizationService;
	}

	public async Task<Response<string>> MigrateTranslations(MigrateModel model)
	{
		var response = new Response<string>();
		var list = await _repository.GetAllAsync(Constants.K_Table.Localization, cm.GetConnectionString(model));
		foreach (var item in list.Take(10)) 
		{
			// ค้นหา Dictionary Item ตาม Key
			var dictionaryItem = _localizationService.GetDictionaryItemByKey(item.StringKey);
			if (dictionaryItem == null)
			{
				// หากยังไม่มี Dictionary Item สร้างใหม่
				dictionaryItem = new DictionaryItem(item.StringKey);
				_localizationService.Save(dictionaryItem);
			}

			// ค้นหา Language
			var language = _localizationService.GetLanguageByIsoCode(item.CultureCode);

			if (language == null)
			{
				response.message = $"Language with ISO code '{item.CultureCode}' not found.";
				return response;
			}

			// เพิ่มหรืออัปเดต Translation
			var translation = dictionaryItem.Translations.FirstOrDefault(t => t.Language.Id == language.Id);
			if (translation == null)
			{
				// หากไม่มีการแปลสำหรับภาษานี้ให้เพิ่มการแปลใหม่
				translation = new DictionaryTranslation(language, item.TranslationText);
				dictionaryItem.Translations = dictionaryItem.Translations.Concat(new[] { translation }).ToList();  // ใช้ Concat และ ToList เพื่อเพิ่มการแปล
			}
			else
			{
				translation.Value = item.TranslationText;
			}

			// บันทึกการเปลี่ยนแปลง
			_localizationService.Save(dictionaryItem);

			response.isSuccess = true;
			response.message = Constants.Message.MigrationSuccess;
		}

		return response;
	}
}
