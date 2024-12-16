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
	private readonly ITranslationsService _service;
	Commons cm = new Commons();	

	public MigrateController(
		IUmbracoContextAccessor umbracoContextAccessor, 
		IUmbracoDatabaseFactory databaseFactory, 
		ServiceContext services, 
		AppCaches appCaches, 
		IProfilingLogger profilingLogger, 
		IPublishedUrlProvider publishedUrlProvider,
		ITranslationsService service) 
			: base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult Index()
	{
		var model = new MigrateModel();
		var listMigrate = cm.GetMigrateTypes();
		if (listMigrate.Count > 0) ViewBag.listMigrate = listMigrate;

		return View(model);
	}

	[HttpPost("submit")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Submit(MigrateModel model)
	{
		var response = new Response<string>();
		if (model != null)
		{
			string connectionString = cm.GetConnectionString(model);
			response = await _service.MigrateTranslations(connectionString);

			return Json(new { success = true, message = "Migration successful!" });
		}

		return Json(new { success = false, message = "Invalid data submitted." });
	}

}
