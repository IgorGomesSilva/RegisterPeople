using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);

        Task Update(TEntity obj);

        Task Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);
    }
}
