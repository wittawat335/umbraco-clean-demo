
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Services;

public class PageTypeService : IPageTypeService
{
	public Task<Response<string>> MigratePageType(MigrateModel model)
	{
		throw new NotImplementedException();
	}
}
