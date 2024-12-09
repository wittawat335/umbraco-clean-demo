using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using umbraco_clean_demo.Web.Models.ViewModels;

namespace umbraco_clean_demo.Web.Controllers.Surface;

[Route("migrate")]
public class MigrateController : SurfaceController
{
	public MigrateController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
	{
	}

	[HttpGet]
	public IActionResult Index()
	{
		var model = new MigrateModel();
		return View(model);
	}

	[HttpPost("submit")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Submit(MigrateModel model)
	{
		if (model != null)
		{
			return Json(new { success = true, message = "Migration successful!" });
		}

		return Json(new { success = false, message = "Invalid data submitted." });
	}

}
