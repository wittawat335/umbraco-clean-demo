using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace umbraco_clean_demo.Infrastructure.DBContext;

public class DapperContext
{
	private readonly IConfiguration _configuration;
	private readonly string _connectionString;
	public DapperContext(IConfiguration configuration)
	{
		_configuration = configuration;
		_connectionString = configuration.GetConnectionString("umbracoDbDSN");
	}
	public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
