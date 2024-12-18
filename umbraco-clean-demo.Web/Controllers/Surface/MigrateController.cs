using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using umbraco_clean_demo.Application;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Infrastructure.Utilities;

namespace umbraco_clean_demo.Web.Controllers.Surface;

[Route("migrate")]
public class MigrateController : SurfaceController
{
	private readonly ITranslationsService _translationsService;
	private readonly IPageTypeService _pageTypeService;
	private readonly IUserRoleService _userRoleService;
	Commons cm = new Commons();	

	public MigrateController(
		IUmbracoContextAccessor umbracoContextAccessor, 
		IUmbracoDatabaseFactory databaseFactory, 
		ServiceContext services, 
		AppCaches appCaches, 
		IProfilingLogger profilingLogger, 
		IPublishedUrlProvider publishedUrlProvider,
		ITranslationsService translationsService,
		IUserRoleService userRoleService,
		IPageTypeService pageTypeService) 
			: base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
	{
		_translationsService = translationsService;
		_pageTypeService = pageTypeService;
		_userRoleService = userRoleService;
	}

	[HttpGet]
	public IActionResult Index()
	{
		var model = new MigrateModel();
		var listMigrate = cm.GetListMigrate();
		if (listMigrate.Count > 0) ViewBag.listMigrate = listMigrate;

		return View(model);
	}

	[HttpPost("submit")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Submit(MigrateModel model)
	{
		var response = model.SelectedMigrateType switch
		{
			Constants.MigrateType.Translations => await _translationsService.MigrateTranslations(model),
			Constants.MigrateType.PageType => await _pageTypeService.MigratePageType(model),
			Constants.MigrateType.Role => await _userRoleService.MigrateRoles(model),
			Constants.MigrateType.User => await _userRoleService.MigrateUsers(model),
			_ => new Response<string>()
		};

		return Json(response);
	}
}
