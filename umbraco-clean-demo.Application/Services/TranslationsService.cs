using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;

namespace umbraco_clean_demo.Application.Services;

public class TranslationsService : ITranslationsService
{
	private readonly IGenericRepository<LocalizationModel> _repository;
	private readonly ILocalizationService _localizationService;

	public TranslationsService(IGenericRepository<LocalizationModel> repository, ILocalizationService localizationService)
	{
		_repository = repository;
		_localizationService = localizationService;
	}

	public async Task<Response<string>> MigrateTranslations(string connectionString)
	{
		var response = new Response<string>();
		var list = await _repository.GetAllAsync("View_CMS_ResourceString_Joined", connectionString);
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
				throw new Exception($"Language with ISO code '{item.CultureCode}' not found.");
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
		}
		

		//if (existingValue == null)
		//{
		//	// หากยังไม่มีคีย์ ให้เพิ่มคีย์และค่าการแปล
		//	_dictionaryService.SetValue(model.StringKey, new Dictionary<string, string>
		//	{
		//		{ model.LanguageCode, model.TranslationText }
		//	});
		//}
		//else
		//{
		//	// หากมีคีย์อยู่แล้ว ให้อัปเดตคำแปลสำหรับภาษาที่กำหนด
		//	if (existingValue is Dictionary<string, string> translations)
		//	{
		//		translations[model.LanguageCode] = model.TranslationValue;
		//		_dictionaryService.SetValue(model.StringKey, translations);
		//	}
		//	else
		//	{
		//		// กรณีที่ค่าที่ดึงมาไม่ใช่ Dictionary<string, string>
		//		response.Data = "The existing value is invalid.";
		//		response.Success = false;
		//		return response;
		//	}
		//}

		return response;
	}
}
