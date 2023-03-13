using RegisterPeople.Application.Dtos;
using RegisterPeople.Application.Dtos.Address;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Interfaces
{
    public interface IAddressApplicationService
    {
        Task AddAsync(AddressDtoCreate addressDto);
        Task UpdateAsync(AddressDtoUpdate addressDto);
        Task RemoveAsync(int id);
        Task<IEnumerable<AddressDto>> GetAllAsync();
        Task<AddressDto> GetByIdAsync(int id);

        Task<IEnumerable<AddressDto>> GetByIdPersonAsync(int idPerson);
    }
}
