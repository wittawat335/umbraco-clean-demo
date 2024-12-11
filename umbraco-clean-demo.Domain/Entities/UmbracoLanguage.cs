namespace umbraco_clean_demo.Domain.Entities;
public class UmbracoLanguage
{
	public int Id { get; set; }
	public string LanguageISOCode { get; set; }
	public string LanguageCultureName { get; set; }
	public bool IsDefaultVariantLang { get; set; }
	public bool Mandatory { get; set; }
	public int? FallbackLanguageId { get; set; } 
}
