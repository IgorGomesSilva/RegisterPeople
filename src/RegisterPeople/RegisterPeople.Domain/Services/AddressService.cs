using RegisterPeople.Domain.Entitys;
using RegisterPeople.Domain.Interfaces.Repository;
using RegisterPeople.Domain.Interfaces.Service;

namespace RegisterPeople.Domain.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
