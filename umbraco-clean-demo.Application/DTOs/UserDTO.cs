namespace umbraco_clean_demo.Application.DTOs;

public class UserDTO
{
	public int id { get; set; }
	public bool userDisabled { get; set; }
	public bool userNoConsole { get; set; }
	public string userName { get; set; }
	public string userLogin { get; set; }
	public string userPassword { get; set; }
	public string passwordConfig { get; set; }
	public string userEmail { get; set; }
	public string userLanguage { get; set; }
	public string securityStampToken { get; set; }
	public int failedLoginAttempts { get; set; }
	public DateTime lastLockoutDate { get; set; }
	public DateTime lastPasswordChangeDate { get; set; }
	public DateTime lastLoginDate { get; set; }
	public DateTime emailConfirmedDate { get; set; }
	public DateTime invitedDate { get; set; }
	public DateTime createDate { get; set; }
	public DateTime updateDate { get; set; }
	public string avatar { get; set; }
	public string tourData { get; set; }
}
