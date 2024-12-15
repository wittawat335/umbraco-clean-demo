using System.Web.Mvc;

namespace umbraco_clean_demo.Infrastructure.Utilities;

public class Commons
{
	public List<SelectListItem> GetMigrateTypes()
	{
		var list = new List<SelectListItem>{
				new SelectListItem { Value = "Localization", Text = "Localization" },
				new SelectListItem { Value = "User", Text = "User" },
				new SelectListItem { Value = "AddUserToSite", Text = "AddUserToSite" },
				new SelectListItem { Value = "Role", Text = "Role" },
				new SelectListItem { Value = "DeleteCustomtable", Text = "Delete Data Customtable" },
				new SelectListItem { Value = "InsertCustomtable", Text = "Insert Data Customtable" },
				new SelectListItem { Value = "PageType", Text = "Page Type" }
			};
		return list;
	}
}
