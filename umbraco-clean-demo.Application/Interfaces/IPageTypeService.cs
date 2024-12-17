﻿
using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Application.Interfaces;

public interface IPageTypeService
{
	Task<Response<string>> MigratePageType(MigrateModel model);
}
