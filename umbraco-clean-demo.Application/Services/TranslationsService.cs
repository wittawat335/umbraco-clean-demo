using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Application.Services;

public class TranslationsService(IMigrateRepository<LocalizationModel> _repository, ILocalizationService _service) : ITranslationsService
{
	public async Task<Response<string>> MigrateTranslations(MigrateModel model)
	{
		var response = new Response<string>();
		var list = await _repository.GetAllAsync(Constants.K_Table.Localization, model);
		foreach (var item in list.Take(10)) 
		{
			var dictionaryItem = _service.GetDictionaryItemByKey(item.StringKey);   // ค้นหา Dictionary Item ตาม Key
			if (dictionaryItem == null) 
			{
				dictionaryItem = new DictionaryItem(item.StringKey); // หากยังไม่มี Dictionary Item สร้างใหม่
				_service.Save(dictionaryItem);
			}

			var language = _service.GetLanguageByIsoCode(item.CultureCode); // ค้นหา Language ในฝั่ง Umbraco
			if (language == null)
			{
				response.message = $"Language with ISO code '{item.CultureCode}' not found.";
				return response;
			}

			var translation = dictionaryItem.Translations.FirstOrDefault(_ => _.Language.Id == language.Id); // เพิ่มหรืออัปเดต Translation
			if (translation == null) // insert
			{
				translation = new DictionaryTranslation(language, item.TranslationText); // หากไม่มีการแปลสำหรับภาษานี้ให้เพิ่มการแปลใหม่
				dictionaryItem.Translations = dictionaryItem.Translations.Concat(new[] { translation }).ToList();  // ใช้ Concat และ ToList เพื่อเพิ่มการแปล
			}
			else // update
			{
				translation.Value = item.TranslationText;
			}

			_service.Save(dictionaryItem);

			response.isSuccess = true;
			response.message = Constants.Message.MigrationSuccess;
		}

		return response;
	}
}
