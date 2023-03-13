using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;
using RegisterPeople.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Domain.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetByIdPersonAsync(int idPerson)
        {
            return await _addressRepository.GetByIdPerson(idPerson);
        }
    }
}
