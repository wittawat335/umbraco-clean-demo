﻿using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IMediasRepository<T> where T : class
{
	Task<List<T>> GetAllAsync(string tableName, MigrateModel model);
	Task MigrateMediaTest();
	Task<T> GetByIdAsync(object id);
	Task<int> InsertAsync(T entity);
	Task<int> UpdateAsync(T entity);
	Task<int> DeleteAsync(object id);
}

