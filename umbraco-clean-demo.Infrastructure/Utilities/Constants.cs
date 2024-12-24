namespace umbraco_clean_demo.Infrastructure.Utilities;

public static class Constants
{
	public struct K_Table
	{
		public const string Localization = "View_CMS_ResourceString_Joined";
		public const string Users = "CMS_User";
		public const string UserSettingsRole = "View_CMS_UserSettingsRole_Joined";
		public const string Attachment = "CMS_Attachment";
	}

	public struct MigrateType
	{
		public const string Translations = "Translations";
		public const string User = "User";
		public const string AddUser2UserGroup = "AddUser2UserGroup";
		public const string UserGroup = "UserGroup";
		public const string DeleteCustomtable = "DeleteCustomtable";
		public const string InsertCustomtable = "InsertCustomtable";
		public const string Content = "Content";
	}

	public struct Message
	{
		public const string MigrationSuccess = "Migration was successful!";
		public const string DeleteSuccess = "Delete was successful!";
		public const string Migrationfailed = "Migration failed. Please try again.";
		public const string PleaseSelectPageType = "Please Select Page Type";
	}

	public struct SQLCommand
	{
		#region GetData
		public const string GetUserRoles
			= "SELECT U.UserID, U.UserName, U.Email, R.RoleID, R.RoleName, UR.UserRoleID FROM CMS_User AS U INNER JOIN CMS_UserRole AS UR ON U.UserID = UR.UserID INNER JOIN CMS_Role AS R ON UR.RoleID = R.RoleID";

		#endregion


	}
}
