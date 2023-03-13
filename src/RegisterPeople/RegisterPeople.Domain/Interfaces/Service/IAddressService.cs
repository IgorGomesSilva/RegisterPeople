using RegisterPeople.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Interfaces.Service
{
    public interface IAddressService : IServiceBase<Address>
    {
        Task<IEnumerable<Address>> GetByIdPersonAsync(int idPerson);
    }
}
