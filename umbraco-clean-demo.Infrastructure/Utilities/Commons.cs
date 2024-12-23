using System.Data.SqlClient;
using System.Web.Mvc;
using Umbraco.Cms.Core.Models.Membership;
using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Infrastructure.Utilities;

public class Commons
{
	public List<SelectListItem> GetListMigrate()
	{
		var list = new List<SelectListItem>{
				new SelectListItem { Value = "Translations", Text = "Translations" },
				new SelectListItem { Value = "User", Text = "User" },
				new SelectListItem { Value = "AddUser2UserGroup", Text = "Add User to UserGroup" },
				//new SelectListItem { Value = "Member", Text = "Member" },
				new SelectListItem { Value = "UserGroup", Text = "UserGroup" },
				//new SelectListItem { Value = "DeleteCustomtable", Text = "Delete Data Customtable" },
				//new SelectListItem { Value = "InsertCustomtable", Text = "Insert Data Customtable" },
				//new SelectListItem { Value = "PageType", Text = "Page Type" }
			};
		return list;
	}

	public string GetConnectionString(MigrateModel model)
	{
		string connectionString = new SqlConnectionStringBuilder
		{
			DataSource = model.ServerName,
			InitialCatalog = model.DatabaseName,
			UserID = model.DBUserName,
			Password = model.DBPassword
		}.ConnectionString;

		return connectionString;
	}
}
