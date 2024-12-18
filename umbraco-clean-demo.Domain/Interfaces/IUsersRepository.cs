﻿using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IUsersRepository
{
	Task<List<UserRoleModel>> GetUserRoles(string connectionString);
	Task<List<UserRoleModel>> GetUserRolesFromView(string connectionString);
	Task<bool> InsertRoles(List<UserRoleModel> model);
}