﻿
using Umbraco.Cms.Core.Services;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Services;

public class PageTypeService : IPageTypeService
{
	private readonly IContentTypeService _contentTypeService;
	private readonly IContentService _contentService;
	public Task<Response<string>> MigratePageType(MigrateModel model)
	{
		throw new NotImplementedException();
	}
}
