namespace umbraco_clean_demo.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
	Task<List<T>> GetAllAsync();
	Task<T> GetByIdAsync(object id);
	Task<int> InsertAsync(T entity);
	Task<int> UpdateAsync(T entity);
	Task<int> DeleteAsync(object id);
}
