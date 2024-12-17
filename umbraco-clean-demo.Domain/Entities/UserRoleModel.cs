namespace umbraco_clean_demo.Domain.Entities;

public class UserRoleModel
{
	public int UserID { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public int RoleID { get; set; }
	public string RoleName { get; set; }
}
