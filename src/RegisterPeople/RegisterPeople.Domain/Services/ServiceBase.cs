using RegisterPeople.Domain.Interfaces.Repository;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task Add(TEntity obj)
        {
            await repository.Add(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task Remove(TEntity obj)
        {
            await repository.Remove(obj);
        }

        public async Task Update(TEntity obj)
        {
            await repository.Update(obj);
        }
    }
}
