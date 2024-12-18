namespace umbraco_clean_demo.Domain.Entities;
public class Role
{
	public int RoleID { get; set; }
	public string RoleDisplayName { get; set; }
	public string RoleName { get; set; }
	public DateTime RoleLastModified { get; set; }
	public int RoleGroupID { get; set; }
	public bool RoleIsGroupAdministrator { get; set; }
	public bool RoleIsDomain { get; set; }
}
