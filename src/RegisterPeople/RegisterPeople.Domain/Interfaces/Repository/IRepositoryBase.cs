using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity obj);

        Task UpdateAsync(TEntity obj);

        Task RemoveAsync(TEntity obj);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);
    }
}
