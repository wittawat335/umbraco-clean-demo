namespace umbraco_clean_demo.Web.Models.ViewModels
{
	public class MigrateModel
	{
		public string ServerName { get; set; } = "10.16.1.63,1431";

		public string DatabaseName { get; set; } = "KSAMCMS11";

		public string DBUserName { get; set; } = "ksamuser";

		public string DBPassword { get; set; } = string.Empty;

		public string SelectedMigrateType { get; set; } 

		public string SelectedPageType { get; set; } 
	}
}
