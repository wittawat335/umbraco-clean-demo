namespace umbraco_clean_demo.Domain.Entities.Kentico;

public class Users
{
	public int UserID { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string PreferredUICultureCode { get; set; }
	public bool UserEnabled { get; set; }
	public DateTime UserCreated { get; set; }
	public DateTime LastLogon { get; set; }
	public DateTime UserLastModified { get; set; }
	public bool UserIsDomain { get; set; }
	public bool UserHasAllowedCultures { get; set; }
}

