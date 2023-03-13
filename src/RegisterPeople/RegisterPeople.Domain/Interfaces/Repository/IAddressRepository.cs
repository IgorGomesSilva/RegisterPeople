using RegisterPeople.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Interfaces.Repository
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Task<IEnumerable<Address>> GetByIdPerson(int idPerson);
    }
}
