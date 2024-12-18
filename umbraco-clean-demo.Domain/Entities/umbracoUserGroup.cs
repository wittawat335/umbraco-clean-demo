namespace umbraco_clean_demo.Domain.Entities;
public class umbracoUserGroup
{
	public int id { get; set; }
	public string userGroupAlias { get; set; }
	public string userGroupName { get; set; }
	public string userGroupDefaultPermissions { get; set; }
	public DateTime createDate { get; set; }
	public DateTime updateDate { get; set; }
	public string icon { get; set; }
	public bool hasAccessToAllLanguages { get; set; }
	public int startContentId { get; set; }
	public int startMediaId { get; set; }
}


