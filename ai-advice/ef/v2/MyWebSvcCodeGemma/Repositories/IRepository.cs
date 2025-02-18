using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository
{
Task<IEnumerable> GetAllAsync();
Task GetByIdAsync(int id);
Task AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(int id);
}
