namespace umbraco_clean_demo.Infrastructure.Utilities;

public static class Constants
{
	public struct K_Table
	{
		public const string Localization = "View_CMS_ResourceString_Joined";
	}

	public struct MigrateType
	{
		public const string Translations = "Translations";
		public const string User = "User";
		public const string AddUserToSite = "AddUserToSite";
		public const string Role = "Role";
		public const string DeleteCustomtable = "DeleteCustomtable";
		public const string InsertCustomtable = "InsertCustomtable";
		public const string PageType = "PageType";
	}

	public struct Message
	{
		public const string MigrationSuccess = "Migration was successful!";
		public const string DeleteSuccess = "Delete was successful!";
		public const string Migrationfailed = "Migration failed. Please try again.";
		public const string PleaseSelectPageType = "Please Select Page Type";
	}
}
