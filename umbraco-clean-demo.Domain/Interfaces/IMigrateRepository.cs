using umbraco_clean_demo.Domain.Entities;

namespace umbraco_clean_demo.Domain.Interfaces;

public interface IMigrateRepository<T> where T : class
{
	Task<List<T>> GetAllAsync(string tableName, MigrateModel model);
	Task MigrateTest();
	Task<T> GetByIdAsync(object id);
	Task<int> InsertAsync(T entity);
	Task<int> UpdateAsync(T entity);
	Task<int> DeleteAsync(object id);
}

