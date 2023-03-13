using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Interfaces
{
    public interface IAddressApplicationService
    {
        Task Add(AddressDtoCreate addressDto);
        Task Update(AddressDtoUpdate addressDto);
        Task Remove(int id);
        Task<IEnumerable<AddressDto>> GetAll();
        Task<AddressDto> GetById(int id);
    }
}
